using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AutomobiliuValdymoSistema2;
using Dapper;


namespace AutomobiliuValdymoSistema2
{
    public class NuomaConsoleUI
    {
        private readonly INuomaService _nuomaService;

        public NuomaConsoleUI(INuomaService nuomaService)
        {
            _nuomaService = nuomaService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Pasirinkite veiksmą:");
                Console.WriteLine("1. Registruoti naują naftos kuro automobilį");
                Console.WriteLine("2. Registruoti naują elektromobilį");
                Console.WriteLine("3. Peržiūrėti visus automobilius");
                Console.WriteLine("4. Atnaujinti automobilio informaciją");
                Console.WriteLine("5. Ištrinti automobilį");
                Console.WriteLine("6. Registruoti naują klientą");
                Console.WriteLine("7. Išnuomoti automobilį");
                Console.WriteLine("0. Išeiti");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RegisterNaftosKuroAutomobilis();
                        break;
                    case "2":
                        RegisterElektromobilis();
                        break;
                    case "3":
                        ViewAllAutomobiliai();
                        break;
                    case "4":
                        UpdateAutomobilis();
                        break;
                    case "5":
                        DeleteAutomobilis();
                        break;
                    case "6":
                        RegisterKlientas();
                        break;
                    case "7":
                        RentAutomobilis();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas.");
                        break;
                }
            }
        }

        private void RegisterNaftosKuroAutomobilis()
        {
            Console.WriteLine("Įveskite markę:");
            var marke = Console.ReadLine();

            Console.WriteLine("Įveskite modelį:");
            var modelis = Console.ReadLine();

            Console.WriteLine("Įveskite metus:");
            var metai = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite registracijos numerį:");
            var registracijosNumeris = Console.ReadLine();

            Console.WriteLine("Įveskite bako talpą:");
            var bakoTalpa = double.Parse(Console.ReadLine());

            var automobilis = new NaftosKuroAutomobilis
            {
                Marke = marke,
                Modelis = modelis,
                Metai = metai,
                RegistracijosNumeris = registracijosNumeris,
                BakoTalpa = bakoTalpa
            };

            _nuomaService.RegisterNaftosKuroAutomobilis(automobilis);
            Console.WriteLine("Naftos kuro automobilis sėkmingai užregistruotas.");
        }

        private void RegisterElektromobilis()
        {
            Console.WriteLine("Įveskite markę:");
            var marke = Console.ReadLine();

            Console.WriteLine("Įveskite modelį:");
            var modelis = Console.ReadLine();

            Console.WriteLine("Įveskite metus:");
            var metai = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite registracijos numerį:");
            var registracijosNumeris = Console.ReadLine();

            Console.WriteLine("Įveskite baterijos talpą:");
            var baterijosTalpa = double.Parse(Console.ReadLine());

            var automobilis = new Elektromobilis
            {
                Marke = marke,
                Modelis = modelis,
                Metai = metai,
                RegistracijosNumeris = registracijosNumeris,
                BaterijosTalpa = baterijosTalpa
            };

            _nuomaService.RegisterElektromobilis(automobilis);
            Console.WriteLine("Elektromobilis sėkmingai užregistruotas.");
        }

        private void ViewAllAutomobiliai()
        {
            var automobiliai = _nuomaService.GetAllAutomobiliai();
            foreach (var automobilis in automobiliai)
            {
                Console.WriteLine($"ID: {automobilis.Id}, Marke: {automobilis.Marke}, Modelis: {automobilis.Modelis}, Metai: {automobilis.Metai}, Registracijos numeris: {automobilis.RegistracijosNumeris}");
            }
        }

        private void UpdateAutomobilis()
        {
            Console.WriteLine("Įveskite automobilio ID, kurį norite atnaujinti:");
            var id = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite naują markę:");
            var marke = Console.ReadLine();

            Console.WriteLine("Įveskite naują modelį:");
            var modelis = Console.ReadLine();

            Console.WriteLine("Įveskite naujus metus:");
            var metai = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite naują registracijos numerį:");
            var registracijosNumeris = Console.ReadLine();

            var automobilis = new Automobilis
            {
                Id = id,
                Marke = marke,
                Modelis = modelis,
                Metai = metai,
                RegistracijosNumeris = registracijosNumeris
            };

            _nuomaService.UpdateAutomobilis(automobilis);
            Console.WriteLine("Automobilio informacija sėkmingai atnaujinta.");
        }

        private void DeleteAutomobilis()
        {
            Console.WriteLine("Įveskite automobilio ID, kurį norite ištrinti:");
            var id = int.Parse(Console.ReadLine());

            _nuomaService.DeleteAutomobilis(id);
            Console.WriteLine("Automobilis sėkmingai ištrintas.");
        }

        private void RegisterKlientas()
        {
            Console.WriteLine("Įveskite kliento vardą:");
            var vardas = Console.ReadLine();

            Console.WriteLine("Įveskite kliento pavardę:");
            var pavarde = Console.ReadLine();

            var klientas = new Klientas
            {
                Vardas = vardas,
                Pavarde = pavarde,
                RegistracijosData = DateTime.Now
            };

            _nuomaService.RegisterKlientas(klientas);
            Console.WriteLine("Klientas sėkmingai užregistruotas.");
        }

        private void RentAutomobilis()
        {
            Console.WriteLine("Įveskite automobilio ID:");
            var automobilisId = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite kliento ID:");
            var klientasId = int.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite nuomos pradžios datą (yyyy-mm-dd):");
            var nuo = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Įveskite nuomos pabaigos datą (yyyy-mm-dd):");
            var iki = DateTime.Parse(Console.ReadLine());

            _nuomaService.RentAutomobilis(automobilisId, klientasId, nuo, iki);
            Console.WriteLine("Automobilis sėkmingai išnuomotas.");
        }
    }
}
