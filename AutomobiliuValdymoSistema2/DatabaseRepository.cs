using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutomobiliuValdymoSistema2;
using Dapper;

namespace AutomobiliuValdymoSistema2
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAutomobilis(Automobilis automobilis)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Automobiliai (Marke, Modelis, Metai, RegistracijosNumeris) VALUES(@Marke, @Modelis, @Metai, @RegistracijosNumeris); SELECT CAST(SCOPE_IDENTITY() as int)";
                int automobilisId = db.QuerySingle<int>(sqlQuery, automobilis);
                automobilis.Id = automobilisId;
            }
        }

        public void AddNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis)
        {
            AddAutomobilis(automobilis);
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO NaftosKuroAutomobiliai (AutomobilisId, BakoTalpa) VALUES(@AutomobilisId, @BakoTalpa)";
                db.Execute(sqlQuery, new { AutomobilisId = automobilis.Id, BakoTalpa = automobilis.BakoTalpa });
            }
        }

        public void AddElektromobilis(Elektromobilis automobilis)
        {
            AddAutomobilis(automobilis);
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Elektromobiliai (AutomobilisId, BaterijosTalpa) VALUES(@AutomobilisId, @BaterijosTalpa)";
                db.Execute(sqlQuery, new { AutomobilisId = automobilis.Id, BaterijosTalpa = automobilis.BaterijosTalpa });
            }
        }

        public List<Automobilis> GetAllAutomobiliai()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Automobilis>("SELECT * FROM Automobiliai").AsList();
            }
        }

        public void UpdateAutomobilis(Automobilis automobilis)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Automobiliai SET Marke = @Marke, Modelis = @Modelis, Metai = @Metai, RegistracijosNumeris = @RegistracijosNumeris WHERE Id = @Id";
                db.Execute(sqlQuery, automobilis);
            }
        }

        public void DeleteAutomobilis(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Automobiliai WHERE Id = @Id";
                db.Execute(sqlQuery, new { Id = id });
            }
        }

        public void AddKlientas(Klientas klientas)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Klientai (Vardas, Pavarde, RegistracijosData) VALUES(@Vardas, @Pavarde, @RegistracijosData)";
                db.Execute(sqlQuery, klientas);
            }
        }

        public void RentAutomobilis(Nuoma nuoma)
        {
            if (!IsAutomobilisAvailable(nuoma.AutomobilisId, nuoma.DataNuo, nuoma.DataIki))
            {
                throw new InvalidOperationException("Automobilis is already rented for the selected period.");
            }

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Nuoma (AutomobilisId, KlientasId, Nuo, Iki) VALUES(@AutomobilisId, @KlientasId, @Nuo, @Iki)";
                db.Execute(sqlQuery, nuoma);
            }
        }

        public bool IsAutomobilisAvailable(int automobilisId, DateTime nuo, DateTime iki)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT COUNT(*) FROM Nuoma WHERE AutomobilisId = @AutomobilisId AND ((@Nuo BETWEEN Nuo AND Iki) OR (@Iki BETWEEN Nuo AND Iki))";
                int count = db.QuerySingle<int>(sqlQuery, new { AutomobilisId = automobilisId, Nuo = nuo, Iki = iki });
                return count == 0;
            }
        }
    }
}
