namespace Smart.Admin.Template.RestApi.Gateways.Mongo.Core;

using MongoDB.Bson.Serialization;
using MongoDB.Driver;

public interface IMongoRepository
{
    IMongoDatabase Database { get; }

    IMongoClient Client { get; }

    BsonClassMap GetMapping(Type type);
}