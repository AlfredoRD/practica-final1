using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Models
{
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            UsuarioContext db = new UsuarioContext();
            {

                return View(db.AspNetUserRoles.ToList());
            }
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AspNetUserRoles a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (UsuarioContext db = new UsuarioContext())
                {
                    if (a.RoleId == "1")
                    {
                        a.RolesName = "Administrador";
                    }
                    if (a.RoleId == "2")
                    {
                        a.RolesName = "Usuario";
                    }
                    else if(a.RoleId == "3")
                    {
                        a.RolesName = "Seguridad";
                    }
                    else if (a.RoleId == "4")
                    {
                        a.RolesName = "Gestion";
                    }

                    db.AspNetUserRoles.Add(a);
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

        public ActionResult Editar(string Id, string Id2)
        {
            try
            {
                using (var db = new UsuarioContext())
                {
                    AspNetUserRoles pro = db.AspNetUserRoles.Find(Id, Id2);
                    return View(pro);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AspNetUserRoles a)

        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (var db = new UsuarioContext())
                {
                    AspNetUserRoles user = db.AspNetUserRoles.Find(a.UserId, a.RoleId);

                    user.RolesName = a.RolesName;
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        
        public ActionResult Eliminar(string Id, string id2)
        {
            using (var db = new UsuarioContext())
            {
                AspNetUserRoles Pro = db.AspNetUserRoles.Find(Id,id2);
                db.AspNetUserRoles.Remove(Pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}