namespace Smart.Admin.Template.RestApi.Gateways.Mongo.Mapping;

using MongoDB.Bson.Serialization;

public interface IMongoMap
{
    BsonClassMap RegisterMap();
}