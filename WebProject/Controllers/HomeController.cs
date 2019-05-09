using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			object usuarioLogado = Session["usuarioLogado"];
			if (usuarioLogado != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}

			
        }

		public ActionResult Sair()
		{
			Session["usuarioLogado"] = null;
			return RedirectToAction("Index", "Login");
		}
	}
}