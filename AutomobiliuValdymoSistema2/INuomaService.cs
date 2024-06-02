using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutomobiliuValdymoSistema2;
using Dapper;
namespace AutomobiliuValdymoSistema2
{
    public interface INuomaService
    {
        void RegisterNaftosKuroAutomobilis(NaftosKuroAutomobilis automobilis);
        void RegisterElektromobilis(Elektromobilis automobilis);
        List<Automobilis> GetAllAutomobiliai();
        void UpdateAutomobilis(Automobilis automobilis);
        void DeleteAutomobilis(int id);

        void RegisterKlientas(Klientas klientas);
        void RentAutomobilis(int automobilisId, int klientasId, DateTime nuo, DateTime iki);
    }
}
