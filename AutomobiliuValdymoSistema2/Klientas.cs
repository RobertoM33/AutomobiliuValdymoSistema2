using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobiliuValdymoSistema2
{
   public class Klientas : Nuoma
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime RegistracijosData { get; set; }
    }
}
