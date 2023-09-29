using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Police.Models
{
    public class Verbale
    {
        
            
            [Required(ErrorMessage = "Please insert the violation date in the form 'YYYY-MM-DD'")]
            public string DataViolazione { get; set; }

            [Required(ErrorMessage = "Please insert the address where violation occurred")]
            public string IndirizzoViolazione { get; set; }

            [Required(ErrorMessage = "Please insert the Agent's name")]
            public string NominativoAgente { get; set; }

            [Required(ErrorMessage = "Please insert when the violation is being written as a date in the form 'YYYY-MM-DD'")]
            public string DataTranscrizioneVerbale { get; set; }

            [Required(ErrorMessage = "Please insert an amount as a whole")]
            public double Importo { get; set; }

            [Required(ErrorMessage = "Please insert the amount of point taken off the driver's licence")]
            public int DecurtamentoPunti { get; set; }

            [Required(ErrorMessage = "Please insert they type of Verbale")]
            public int TipoVerbaleID { get; set; }

        public static List<Verbale> VerbaleList { get; set; } = new List<Verbale>();
        }
    }
