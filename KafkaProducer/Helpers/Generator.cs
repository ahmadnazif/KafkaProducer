namespace KafkaProducer.Helpers;

public static class Generator
{
    private static readonly Random random;

    static Generator()
    {
        random = new();
    }

    public static ProduceSmsRequest GenerateOneSms(string topic)
    {
        return new(topic, new()
        {
             From = $"60{random.Next(10000000, 90000000)}",
             To = $"60{random.Next(10000000, 90000000)}",
             Text = $"Txt-{Guid.NewGuid().ToString("N").ToUpper()}",
             SentTime = DateTime.Now
        });
    }
}
