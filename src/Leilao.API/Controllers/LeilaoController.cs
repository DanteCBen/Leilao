using Leilao.API.Entities;
using Leilao.API.UseCases.Leiloes.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;


[Route("[controller]")]
[ApiController]
public class LeilaoController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction()
    {
        var useCase = new GetCurrentLeilaoUseCase();

        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);
    }

}
