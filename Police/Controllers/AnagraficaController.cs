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
    public class AnagraficaController : Controller
    {
        
        public ActionResult Index()
        {
            return View(Anagrafica.AnagraficaList);
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(Anagrafica newAnagrafica)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        conn.Open();
                        string insertQuery = "insert into Anagrafica values (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CodFisc, @VerbaleID)";
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("Cognome", newAnagrafica.Cognome);
                            cmd.Parameters.AddWithValue("Nome", newAnagrafica.Nome);
                            cmd.Parameters.AddWithValue("Indirizzo", newAnagrafica.Indirizzo);
                            cmd.Parameters.AddWithValue("Citta", newAnagrafica.Citta);
                            cmd.Parameters.AddWithValue("CAP", newAnagrafica.CAP);
                            cmd.Parameters.AddWithValue("CodFisc", newAnagrafica.CodFisc);
                            cmd.Parameters.AddWithValue("VerbaleID", newAnagrafica.VerbaleID);

                            int insertedSuccessfully = cmd.ExecuteNonQuery();

                            if (insertedSuccessfully > 0)
                            {

                                return RedirectToAction("Index", "Verbale");
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


            return View(newAnagrafica);
        }

        
    }
}
