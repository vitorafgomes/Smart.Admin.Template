namespace Smart.Admin.Template.RestApi.Gateways.Mongo.Core;

using Mapping;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

public sealed class MongoRepository: IMongoRepository
{
    public MongoRepository(MongoUrl url)
    {
        this.Client = new MongoClient(url);
        this.Database = this.Client.GetDatabase(url.DatabaseName);
    }

    static MongoRepository()
    {
        RegisterMaps();
    }
    
    public IMongoDatabase Database { get; }
    public IMongoClient Client { get; }
    public BsonClassMap GetMapping(Type type)
    {
        return BsonClassMap.LookupClassMap(type);
    }
    
    private static void RegisterMaps()
    {
        var mongoMapType = typeof(IMongoMap);

        var mappers = mongoMapType.Assembly
            .GetTypes()
            .Where(x => mongoMapType.IsAssignableFrom(x) && x.IsClass);

        foreach (var mapper in mappers)
        {
            var instance = (IMongoMap)Activator.CreateInstance(mapper);

            instance.RegisterMap();
        }
    }
}