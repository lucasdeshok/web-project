using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace WebProject.DAO
{
	public class ClientMongoDB
	{
		public IMongoDatabase ConectarMongoDB()
		{
			IMongoClient mongoClient = new MongoClient("mongodb://localhost");
			IMongoDatabase mongoDatabase = mongoClient.GetDatabase("webproject");
			return mongoDatabase;
		}
	}
}