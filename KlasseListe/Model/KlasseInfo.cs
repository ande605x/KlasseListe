using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasseListe.Model
{
    public class KlasseInfo
    {
        /// <summary>
        /// Indeholder properties på elever i klassen 
        /// </summary>
        /// 
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string MobilNr { get; set; }
        public string Email { get; set; }
        public string GitNavn { get; set; }

        public override string ToString()
        {
            return Fornavn +" "+ Efternavn + " " + MobilNr + " " + Email + " " + GitNavn;
        }
    }
}
