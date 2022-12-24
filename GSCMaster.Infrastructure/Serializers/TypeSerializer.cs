using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GSCMaster.Infrastructure.Serializers;

public class TypeSerializer : SerializerBase<Type>
{
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Type value)
        => context.Writer.WriteString(value.Identifier);

    public override Type Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        Type.TryParse(context.Reader.ReadString(), out var type);

        return type!;
    }
}