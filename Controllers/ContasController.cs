using Microsoft.AspNetCore.Mvc;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private static readonly List<Conta> _contas = new(){
        new Conta { Id = 1, ClienteId = 1, numero = 10, Tipo = "Corrente", Saldo = 1500.00m, Ativa = true },
        new Conta { Id = 2, ClienteId = 2, numero = 20, Tipo = "Poupança", Saldo = 2500000.00m, Ativa = true },
    };
    public record ValorDto(decimal valor);

    private static int _proximoId = 3;
    

    [HttpGet]
    public ActionResult<List<Conta>> GetTodas([FromQuery] string? tipo)
    {
        if (!string.IsNullOrEmpty(tipo))
        {
            var filtradas = _contas.Where(c => c.Tipo == tipo).ToList();
            return Ok(filtradas);
        }
     return Ok(_contas);
    }

    [HttpGet("{id:int}")] 
        public ActionResult<Conta> GetPorId(int id)
        {
            var conta = _contas.FirstOrDefault(c => c.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            return Ok(conta);
        }

        [HttpPost]
        public ActionResult<Conta> Criar([FromBody] Conta nova)
        {
            nova.Id = _proximoId++;
            _contas.Add(nova);
            return CreatedAtAction(nameof(GetPorId), new { id = nova.Id }, nova);
        }
        [HttpPost("{id:int}/depositar")]
        public ActionResult<Conta> Depositar(int id,  ValorDto valor)
        {
            var conta = _contas.FirstOrDefault(c => c.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            if (valor.valor <= 0)
            {
                return BadRequest("O valor do depósito deve ser maior que zero.");
            }
            conta.Saldo += valor.valor;
            return Ok(conta);
        }

        [HttpPut("{id:int}")]
        public ActionResult Atualizar(int id, Conta dados)
        {
            var conta = _contas.FirstOrDefault(c => c.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            conta.Tipo = dados.Tipo;
            conta.Saldo = dados.Saldo;
            conta.Ativa = dados.Ativa;
         
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Remover(int id)
        {
            var conta = _contas.FirstOrDefault(c => c.Id == id);
            if (conta == null)
            {
                return NotFound();
            }
            _contas.Remove(conta);
            return NoContent();
        }
}  
  
