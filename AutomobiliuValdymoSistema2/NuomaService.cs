using AutomobiliuValdymoSistema2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AutomobiliuValdymoSistema2
{
    public class NuomaService : INuomaService
    {
        private readonly IDatabaseRepository _databaseRepository;

        public NuomaService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        public void RegisterNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis)
        {
            _databaseRepository.AddNaftosKuroAutomobilis(automobilis);
        }

        public void RegisterElektromobilis(Elektromobilis automobilis)
        {
            _databaseRepository.AddElektromobilis(automobilis);
        }

        public List<Automobilis> GetAllAutomobiliai()
        {
            return _databaseRepository.GetAllAutomobiliai();
        }

        public void UpdateAutomobilis(Automobilis automobilis)
        {
            _databaseRepository.UpdateAutomobilis(automobilis);
        }

        public void DeleteAutomobilis(int id)
        {
            _databaseRepository.DeleteAutomobilis(id);
        }

        public void RegisterKlientas(Klientas klientas)
        {
            _databaseRepository.AddKlientas(klientas);
        }

        public void RentAutomobilis(int automobilisId, int klientasId, DateTime nuo, DateTime iki)
        {
            var nuoma = new Nuoma
            {
                AutomobilisId = automobilisId,
                KlientasId = klientasId,
                DataNuo = nuo,
                DataIki = iki
            };
            _databaseRepository.RentAutomobilis(nuoma);
        }
    }
}
