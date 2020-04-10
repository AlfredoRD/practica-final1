using Almacen23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            AlmacenContext db = new AlmacenContext();

            return View(db.Clientes.ToList());

        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Clientes a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (AlmacenContext db = new AlmacenContext())
                {
                    db.Clientes.Add(a);
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
                    Clientes cli = db.Clientes.Find(Id);
                    return View(cli);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Clientes a)

        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new AlmacenContext())
                {
                    Clientes cli = db.Clientes.Find(a.Id);
                    cli.Nombre = a.Nombre;
                    cli.Apellido = a.Apellido;
                    cli.Direccion = a.Direccion;
                    cli.Direccion = a.Correo;
                    cli.Telefono = a.Telefono;
                    cli.Tipo_de_cliente = a.Tipo_de_cliente;
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
                Clientes cli = db.Clientes.Find(Id);
                return View(cli);
            }
  
        }
        public ActionResult Eliminar(int Id)
        {
            using (var db = new AlmacenContext())
            {
                Clientes cli = db.Clientes.Find(Id);
                db.Clientes.Remove(cli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
    }
}
 
