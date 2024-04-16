namespace Smart.Admin.Template.RestApi.Api.Modules;

using Gateways.Mongo.Core;
using Infrastructure.CrossCutting.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

internal static class MongoExtensions
{
    internal static IServiceCollection AddMongoDb(this IServiceCollection serviceCollection, MongoSettings settings)
    {
        ConfigureConventions();

        var mongoUrl = new MongoUrl(settings.ConnectionString);

        var mongoRepository = new MongoRepository(mongoUrl);

        serviceCollection.AddSingleton(mongoRepository.Database);

        serviceCollection.AddDocumentConverters();

        return serviceCollection;
    }

    private static void ConfigureConventions()
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;

        var pack = new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String),
            new IgnoreExtraElementsConvention(true),
        };

        ConventionRegistry.Register("ServiceConventions", pack, t => true);
    }

    private static IServiceCollection AddDocumentConverters(this IServiceCollection serviceCollection)
    {
     

        return serviceCollection;
    }
}