using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almacen23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bienvenido a nuestra pagina el almacen, esta pagina fue creada con el motivo de que usted pueda comprar y vender productos.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Aqui tiene nuestro contactos de pagina.";

            return View();
        }
    }
}