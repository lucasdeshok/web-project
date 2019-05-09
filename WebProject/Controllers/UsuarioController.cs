using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.DAO;
using WebProject.Controllers;

namespace WebProject.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
			UsuariosDAO usuariosDao = new UsuariosDAO();
			var usuarios = usuariosDao.ConsultarTodos();
			return View(usuarios);			
        }
		public ActionResult Form()
		{
			ViewBag.Usuario = new Usuario();			
			return View();
		}

		[ValidateAntiForgeryToken, HttpPost]
		public ActionResult Adicionar(Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				UsuariosDAO usuarioDao = new UsuariosDAO();
				usuarioDao.Adicionar(usuario);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Usuario = usuario;
				return View("Form");
			}
		}
	}
}