using Microsoft.AspNetCore.Mvc;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVESAPI.Interfaces;

namespace ONGLIVES.API.Controllers;

[ApiController]
// [ApiVersion("1.0")]
// [Route("api/v{version:apiVersion}/[controller]")]
[Route("api/[controller]")]
public class OngFinanceirosController : ControllerBase
{
    private readonly IOngFinanceiroService _service;
    public OngFinanceirosController(IOngFinanceiroService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<OngFinanceiro>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetTodos()
    {
        var ongFinanceiros = await _service.PegarTodos();
        return Ok(ongFinanceiros);
    }

    [ProducesResponseType((200), Type = typeof(OngFinanceiro))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorId(int id) 
    {
        var ongFinanceiro = await _service.PegarPorId(id);

        if (ongFinanceiro == null) 
            return NotFound();

        return Ok(ongFinanceiro);
    }

    [ProducesResponseType((200), Type = typeof(EditOngFinanceiroModel))]
    [ProducesResponseType((404))]
    [HttpPut("")]
    public async Task<IActionResult> Put(EditOngFinanceiroModel ongFinanceiro)
    {
        if (ongFinanceiro == null)
            return BadRequest();

        var ongFinanceiroEdit = await _service.Editar(ongFinanceiro);

        if (ongFinanceiroEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ongFinanceiro = await _service.Deletar(id);
        if (ongFinanceiro == false)
            return BadRequest();
            
        return NoContent();
    }

}