namespace KafkaProducer.Models;

public class SmsBase
{
    public string? From { get; set; }
    public string? To { get; set; }
    public string? Text { get; set; }
    public DateTime SentTime { get; set; }
}
