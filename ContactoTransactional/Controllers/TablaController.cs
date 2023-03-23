using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactoTransactional.Models;
using ContactoTransactional.Models.ViewModels;

namespace ContactoTransactional.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        [HttpGet]
        public ActionResult Index() {

            List<ListTablaViewModel> lst;

            // Esta clase DBCRUDCOREEntities hace referencia a la BD 
            // Lo que permite conectarse para realizar CRUD
            using (DBCRUDCOREEntitie db = new DBCRUDCOREEntitie())
            {
                lst = (from d in db.tabla
                       select new ListTablaViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Correo = d.correo
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {

            try
            {
                if (ModelState.IsValid) {

                    using (DBCRUDCOREEntitie db = new DBCRUDCOREEntitie()) {

                        var oTabla = new tabla();
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.FechaNcimiento;
                        oTabla.nombre = model.Nombre;

                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("/Tabla/");
                }

                return View(model);

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

        }
    }
}