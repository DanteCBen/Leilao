﻿using Leilao.API.Entities;
using Leilao.API.UseCases.Leiloes.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;

[Route("[controller]")]
[ApiController]
public class LeilaoController : LeilaoBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentLeilaoUseCase useCase)
    {
        var result = useCase.Execute();

        if (result is null)
            return NoContent();

        return Ok(result);

    }
}
