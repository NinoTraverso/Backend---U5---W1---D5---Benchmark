using Police.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Police.Controllers
{
    public class VerbaleController : Controller
    {
        public ActionResult Index()
        {
            return View(Verbale.VerbaleList);
        }

      

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        
        public ActionResult Create(Verbale newVerbale)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        conn.Open();
                        string insertQuery = "insert into Verbale values (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTranscrizioneVerbale, @Importo, @DecurtamentoPunti, @TipoVerbaleID)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("DataViolazione", newVerbale.DataViolazione);
                            cmd.Parameters.AddWithValue("IndirizzoViolazione", newVerbale.IndirizzoViolazione);
                            cmd.Parameters.AddWithValue("NominativoAgente", newVerbale.NominativoAgente);
                            cmd.Parameters.AddWithValue("DataTranscrizioneVerbale", newVerbale.DataTranscrizioneVerbale);
                            cmd.Parameters.AddWithValue("Importo", newVerbale.Importo);
                            cmd.Parameters.AddWithValue("DecurtamentoPunti", newVerbale.DecurtamentoPunti);
                            cmd.Parameters.AddWithValue("TipoVerbaleID", newVerbale.TipoVerbaleID);

                            int insertedSuccessfully = cmd.ExecuteNonQuery();

                            if (insertedSuccessfully > 0)
                            {
                                
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                Response.Write("Inserted into database!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("Error" + ex.Message);
                }
            }

            
            return View(newVerbale);
        }



    }
}
