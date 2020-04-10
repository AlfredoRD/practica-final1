using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Models
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioContext db = new UsuarioContext();
            {

                return View(db.AspNetUsers.ToList());
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AspNetUsers a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (UsuarioContext db = new UsuarioContext())
                {
                    db.AspNetUsers.Add(a);
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
                using (var db = new UsuarioContext())
                {
                    AspNetUsers Pro = db.AspNetUsers.Find(Id);
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
        public ActionResult Editar(AspNetUsers a)

        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (var db = new UsuarioContext())
                {
                    AspNetUsers user = db.AspNetUsers.Find(a.Id);
                    user.Email = a.Email;
                    user.UserName = a.UserName;
                    
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
            using (var db = new UsuarioContext())
            {
                AspNetUsers Pro = db.AspNetUsers.Find(Id);
                return View(Pro);
            }

        }
        public ActionResult Eliminar(int Id)
        {
            using (var db = new UsuarioContext())
            {
                AspNetUsers Pro = db.AspNetUsers.Find(Id);
                db.AspNetUsers.Remove(Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}