using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Driver;
using WebProject.Models;

namespace WebProject.DAO
{
	public class UsuariosDAO
	{

		public IMongoDatabase ConectarMongoDB()
		{
			IMongoClient mongoClient = new MongoClient("mongodb://localhost");
			IMongoDatabase mongoDatabase = mongoClient.GetDatabase("webproject");
			return mongoDatabase;
		}

		public void Inserir(Usuario usuario)
		{
			var mongoDatabase = ConectarMongoDB();
			IMongoCollection<Usuario> collectionUsuarios = mongoDatabase.GetCollection<Usuario>("usuarios");
			collectionUsuarios.InsertOne(usuario);
		}

		public Usuario ConsultarPorEmailSenha(string email, string senha)
		{
			Usuario usuario = new Usuario();
			var mongoDatabase = ConectarMongoDB();

			IMongoCollection<Usuario> collectionUsuarios = mongoDatabase.GetCollection<Usuario>("usuarios");	


			Expression<Func<Usuario, bool>> filter = x => x.Email.Equals(email) && x.Senha == senha;
			IList<Usuario> itemsUsuario = collectionUsuarios.Find(filter).ToList();

			return usuario;

			//using (var contexto = new EstoqueContext())
			//{
			//	return contexto.Usuarios.FirstOrDefault(u => u.Nome == login && u.Senha == senha);
			//}
		}



		//              Expression<Func<Usuario, bool>> filter = x => x.Nome.Contains(nomeBusca);
		//IList<Usuario> usuariosLista = collectionUsuarios.Find(filter).ToList();





		//Expression<Func<Usuario, bool>> filter =x => x.Email.Contains("email") && x.Senha == senha;
		//IList<Usuario> usuarioLista = collectionUsuarios.Find(filter).ToList();
	}
}