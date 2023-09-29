using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Anagrafica
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string CodFisc { get; set; }
        public int VerbaleID { get; set; }


        public static List<Anagrafica> AnagraficaList { get; set; } = new List<Anagrafica>();
    }
}