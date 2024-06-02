using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using AutomobiliuValdymoSistema2;
using Dapper;

namespace AutomobiliuValdymoSistema2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "server=WKS-1BN-13;Database=Roberto;Integrated Security=True;";//Bandziau visaip ir ivedes User Id =Robis;Password=*****
            try
            {
                IDatabaseRepository databaseRepository = new DatabaseRepository(connectionString);
                INuomaService nuomaService = new NuomaService(databaseRepository);
                NuomaConsoleUI ui = new NuomaConsoleUI(nuomaService);

                ui.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida:" + ex.Message);
            }
        }
    }
}

