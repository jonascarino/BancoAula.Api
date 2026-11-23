using Microsoft.AspNetCore.Mvc;
namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Lógica para obter as contas
        return Ok(new { message = "Api do banco aula no ar" });
    }
}