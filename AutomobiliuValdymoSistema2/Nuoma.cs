using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AutomobiliuValdymoSistema2;
using Dapper;

namespace AutomobiliuValdymoSistema2
{
    public class Nuoma 
    {
        public int Id { get; set; }
        public int AutomobilisId { get; set; }
        public int KlientasId { get; set; } 
        public DateTime DataNuo {  get; set; }
        public DateTime DataIki { get; set; }

    }
}
