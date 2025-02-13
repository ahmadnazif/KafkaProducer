using Confluent.Kafka;

namespace KafkaProducer.Services;

public class ProducerService(ILogger<ProducerService> logger, IProducer<Null, SmsBase> producer) : IProducerService
{
    private readonly ILogger<ProducerService> logger = logger;
    private readonly IProducer<Null, SmsBase> producer = producer;

    public async Task<ResponseBase> ProduceSmsAsync(ProduceSmsRequest message, CancellationToken ct)
    {
        Message<Null, SmsBase> msg = new() { Value = message.Message };
        var dr = await producer.ProduceAsync(message.Topic, msg, ct);

        var txt = $"From: {dr.Message.Value.From}, To: {dr.Message.Value.To}, Txt: {dr.Message.Value.Text}, Status: {dr.Status}";

        Log(txt);
        return new(true, txt);
    }

    private void Log(string msg) => logger.LogInformation($"{DateTime.Now.ToLongTimeString()} | {msg}");
}

public interface IProducerService
{
    Task<ResponseBase> ProduceSmsAsync(ProduceSmsRequest message, CancellationToken ct = default);
}
