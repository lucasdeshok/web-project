using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebProject.Models
{
	public class Usuario
	{
		[BsonId()]
		public int Id { get; set; }
		[BsonElement("nome")]
		public string Nome { get; set; }
		[BsonElement("email")]
		public string Email { get; set; }
		[BsonElement("senha")]
		public string Senha { get; set; }
	}
}