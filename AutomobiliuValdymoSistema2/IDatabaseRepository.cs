using AutomobiliuValdymoSistema2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace AutomobiliuValdymoSistema2
{
    public interface IDatabaseRepository
    {
        void AddAutomobilis(Automobilis automobilis);
        void AddNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis);
        void AddElektromobilis(Elektromobilis automobilis);
        List<Automobilis> GetAllAutomobiliai();
        void UpdateAutomobilis(Automobilis automobilis);
        void DeleteAutomobilis(int id);

        void AddKlientas(Klientas klientas);
        void RentAutomobilis(Nuoma nuoma);
        bool IsAutomobilisAvailable(int automobilisId, DateTime nuo, DateTime iki);
    }
}
