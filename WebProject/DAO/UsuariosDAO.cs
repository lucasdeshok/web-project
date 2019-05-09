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
		ClientMongoDB clientMongoDB = new ClientMongoDB();		
		
		public void Adicionar(Usuario usuario)
		{			
			var mongoDatabase = clientMongoDB.ConectarMongoDB();
			IMongoCollection<Usuario> collectionUsuarios = mongoDatabase.GetCollection<Usuario>("usuarios");
			collectionUsuarios.InsertOne(usuario);
		}

		public Usuario ConsultarPorEmailSenha(string email, string senha)
		{
			Usuario usuario = new Usuario();
			var mongoDatabase = clientMongoDB.ConectarMongoDB();

			IMongoCollection<Usuario> collectionUsuarios = mongoDatabase.GetCollection<Usuario>("usuarios");
			Expression<Func<Usuario, bool>> filter = x => x.Email.Equals(email) && x.Senha == senha;
			usuario = collectionUsuarios.Find(filter).FirstOrDefault();

			return usuario;
		}

		public IList<Usuario> ConsultarTodos()
		{
			var mongoDatabase = clientMongoDB.ConectarMongoDB();

			IMongoCollection<Usuario> collectionUsuarios = mongoDatabase.GetCollection<Usuario>("usuarios");

			Expression<Func<Usuario, bool>> filter = x => x.Nome.Contains("");
			IList<Usuario> usuariosLista = collectionUsuarios.Find(filter).ToList();

			return usuariosLista;
		}
	}
}