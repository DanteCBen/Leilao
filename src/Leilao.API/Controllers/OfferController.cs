using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOffer()
    {
        return Created();
    }
}
