using GSCMaster.Core.Common.Enums;
using GSCMaster.Core.PokemonAggregate;
using GSCMaster.Infrastructure.Serializers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GSCMaster.Infrastructure.Configurations;
public class PokemonMapConfig
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Pokemon>(cm =>
        {
            cm.MapIdProperty(p => p.Id);
            cm.MapProperty(p => p.NationalNumber);
            cm.MapProperty(p => p.Name);
            cm.MapProperty(p => p.Tier).SetSerializer(new EnumSerializer<Tier>(BsonType.String));
            cm.MapProperty(p => p.PrimaryType).SetSerializer(new TypeSerializer());
            cm.MapProperty(p => p.SecondaryType).SetSerializer(new TypeSerializer());
            cm.MapProperty(p => p.DefaultGender);
            cm.MapProperty(p => p.BaseHP);
            cm.MapProperty(p => p.BaseAttack);
            cm.MapProperty(p => p.BaseDefense);
            cm.MapProperty(p => p.BaseSpecialAttack);
            cm.MapProperty(p => p.BaseSpecialDefense);
            cm.MapProperty(p => p.BaseSpeed);
            cm.MapProperty(p => p.PreEvolution);
            cm.MapProperty(p => p.Evolution);
            cm.MapProperty(p => p.Movepool);
        });
    }
}