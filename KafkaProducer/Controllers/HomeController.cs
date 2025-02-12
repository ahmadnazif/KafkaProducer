using Microsoft.AspNetCore.Mvc;

namespace KafkaProducer.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult RedirectToSwagger() => Redirect("swagger");
}

