using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Driver;
using WebProject.Models;
using MongoDB.Bson;

namespace WebProject.DAO
{
	public class ProdutosDAO
	{
		ClientMongoDB clientMongoDB = new ClientMongoDB();

		public void Adicionar(Produto produto)
		{
			var mongoDatabase = clientMongoDB.ConectarMongoDB();
			IMongoCollection<Produto> collectionProdutos = mongoDatabase.GetCollection<Produto>("produtos");
			collectionProdutos.InsertOne(produto);
		}

		public IList<Produto> ConsultarTodos()
		{
			var mongoDatabase = clientMongoDB.ConectarMongoDB();

			IMongoCollection<Produto> collectionProdutos = mongoDatabase.GetCollection<Produto>("produtos");

			Expression<Func<Produto, bool>> filter = x => x.Nome.Contains("");
			IList<Produto> produtoLista = collectionProdutos.Find(filter).ToList();

			return produtoLista;
		}
		public Produto ConsultarPorObjectId(string objectId)
		{			
			var mongoDatabase = clientMongoDB.ConectarMongoDB();

			IMongoCollection<Produto> collectionProdutos = mongoDatabase.GetCollection<Produto>("produtos");

			Expression<Func<Produto, bool>> filter = x => x.Id.Equals(ObjectId.Parse(objectId));
			Produto produto = collectionProdutos.Find(filter).FirstOrDefault();

			return produto;
		}

		public void IncrementarEstoque(string objectId)
		{
			var mongoDatabase = clientMongoDB.ConectarMongoDB();
			IMongoCollection<Produto> collectionProdutos = mongoDatabase.GetCollection<Produto>("produtos");


			Expression<Func<Produto, bool>> filter = x => x.Id.Equals(ObjectId.Parse(objectId));

			Produto produto = collectionProdutos.Find(filter).FirstOrDefault();
			if (produto != null)
			{
				produto.Estoque++;
				ReplaceOneResult result = collectionProdutos.ReplaceOne(filter, produto);
			}

		}

		public void DecrementarEstoque(string objectId)
		{
			var mongoDatabase = clientMongoDB.ConectarMongoDB();
			IMongoCollection<Produto> collectionProdutos = mongoDatabase.GetCollection<Produto>("produtos");


			Expression<Func<Produto, bool>> filter = x => x.Id.Equals(ObjectId.Parse(objectId));

			Produto produto = collectionProdutos.Find(filter).FirstOrDefault();
			if (produto != null)
			{
				produto.Estoque--;
				ReplaceOneResult result = collectionProdutos.ReplaceOne(filter, produto);
			}

		}
	}
}