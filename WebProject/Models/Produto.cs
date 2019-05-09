using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebProject.Models
{
	public class Produto
	{
		[BsonId()]
		public ObjectId Id { get; set; }
		[BsonElement("codigo")]
		public string Codigo { get; set; }
		[BsonElement("nome")]
		public string Nome { get; set; }
		[BsonElement("estoque")]
		public int Estoque { get; set; }			
	}
}