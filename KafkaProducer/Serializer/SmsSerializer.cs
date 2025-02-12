using Confluent.Kafka;
using System.Text;

namespace KafkaProducer.Serializer;

public class SmsSerializer : ISerializer<SmsBase>
{
    public byte[] Serialize(SmsBase data, SerializationContext context)
    {
        if (data == null)
        {
            return null;
        }

        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));
    }

}
