namespace KafkaProducer.Models;

public record ProduceSmsRequest(string? Topic, SmsBase? Message);
