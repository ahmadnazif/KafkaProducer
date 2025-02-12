namespace KafkaProducer.Models;

public record ProduceSms(string? Topic, SmsBase? Message);
