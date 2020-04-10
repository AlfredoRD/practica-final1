using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Models
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            AlmacenContext db = new AlmacenContext();
           
            return View(db.Productos.ToList());
            
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Productos a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (AlmacenContext db = new AlmacenContext())
                {
                    db.Productos.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("error agregar", ex);
                return View();
            }
        }

        public ActionResult Editar(int Id)
        {
            try
            {
                using (var db = new AlmacenContext())
                {
                    Productos Pro = db.Productos.Find(Id);
                    return View(Pro);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Productos a)

        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new AlmacenContext())
                {
                    Productos Pro = db.Productos.Find(a.Id);
                    Pro.Fecha_de_creacion = a.Fecha_de_creacion;
                    Pro.Fecha_de_Vencimiento = a.Fecha_de_Vencimiento;
                    Pro.Nombre = a.Nombre;
                    Pro.Descripcion = a.Descripcion;
                    Pro.UDM = a.UDM;
                    Pro.Costo = a.Costo;
                    Pro.Existencia = a.Existencia;
                    Pro.Estado = a.Estado;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Detalles(int Id)
        {
            using (var db = new AlmacenContext())
            {
                Productos Pro = db.Productos.Find(Id);
                return View(Pro);
            }

        }
        public ActionResult Eliminar(int Id)
        {
            using (var db = new AlmacenContext())
            {
                Productos Pro = db.Productos.Find(Id);
                db.Productos.Remove(Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}


