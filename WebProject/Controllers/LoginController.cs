using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.DAO;

namespace WebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Autenticar(string email, string senha, bool manterLogado = false)
		{
			UsuariosDAO usuariosDao = new UsuariosDAO();
			Usuario usuario = usuariosDao.ConsultarPorEmailSenha(email, senha);

			if (usuario != null)
			{
				if (manterLogado)
				{
					Session["usuarioLogado"] = usuario;
				}

				return RedirectToAction("Index", "Home");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}
	}
}