using Almacen23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Controllers
{
    public class DespachoController : Controller
    {
        // GET: Despacho
        public ActionResult Index()
        {
            AlmacenContext db = new AlmacenContext();

            return View(db.Despacho.ToList());
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Despacho a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (AlmacenContext db = new AlmacenContext())
                {
                    db.Despacho.Add(a);
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
                    Despacho Pro = db.Despacho.Find(Id);
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
        public ActionResult Editar(Despacho a)

        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new AlmacenContext())
                {
                    Despacho Des = db.Despacho.Find(a.Id);
                    Des.Fecha = a.Fecha;
                    Des.Tipo_de_accion = a.Tipo_de_accion;
                    Des.Cliente = a.Cliente;
                    Des.Contacto = a.Contacto;
                    Des.Detalle_de_producto = a.Detalle_de_producto;
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
                Despacho Pro = db.Despacho.Find(Id);
                return View(Pro);
            }

        }
        public ActionResult Eliminar(int Id)
        {
            using (var db = new AlmacenContext())
            {
                Despacho Pro = db.Despacho.Find(Id);
                db.Despacho.Remove(Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
