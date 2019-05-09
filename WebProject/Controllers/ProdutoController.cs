using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.DAO;
using WebProject.Controllers;
using MongoDB.Bson;

namespace WebProject.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
			ProdutosDAO produtosDAO = new ProdutosDAO();
			var produtos = produtosDAO.ConsultarTodos();
			return View(produtos);			
        }

		public ActionResult Form()
		{
			ViewBag.Produto = new Produto();
			return View();
		}

		[ValidateAntiForgeryToken, HttpPost]
		public ActionResult Adicionar(Produto produto)
		{
			if (ModelState.IsValid)
			{
				ProdutosDAO produtosDAO = new ProdutosDAO();
				produtosDAO.Adicionar(produto);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Produto = produto;
				return View("Form");
			}
		}

		public ActionResult IncrementarEstoque(string objectId)
		{
			ProdutosDAO produtosDAO = new ProdutosDAO();
			Produto produto = produtosDAO.ConsultarPorObjectId(objectId);
			produto.Estoque++;
			produtosDAO.IncrementarEstoque(objectId);
			return Json(produto);
		}

		public ActionResult DecrementarEstoque(string objectId)
		{
			ProdutosDAO produtosDAO = new ProdutosDAO();
			Produto produto = produtosDAO.ConsultarPorObjectId(objectId);
			produto.Estoque--;
			produtosDAO.DecrementarEstoque(objectId);
			return Json(produto);
		}
	}
}