using KafkaProducer.Models;
using Microsoft.AspNetCore.Mvc;

namespace KafkaProducer.Controllers;

[Route("api/kafka")]
[ApiController]
public class KafkaController(ILogger<KafkaController> logger, IProducerService producer): ControllerBase
{
	private readonly ILogger<KafkaController> logger = logger;
    private readonly IProducerService producer = producer;

    [HttpPost("produce-one-random-sms")]
    public async Task<ActionResult<ResponseBase>> Produce()
    {
        try
        {
            var pro = Generator.GenerateOneSms("Topic1");
            return await producer.ProduceSmsAsync(pro);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return new ResponseBase(false, ex.Message);
        }
    }
}
