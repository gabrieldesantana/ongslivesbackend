using Microsoft.AspNetCore.Mvc;
using ONGLIVESAPI.Interfaces;

namespace ONGLIVES.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
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
    public async Task<IActionResult> GetTodosAsync()
    {
        var ongFinanceiros = await _service.PegarTodosAsync();
        return Ok(ongFinanceiros);
    }

    [ProducesResponseType((200), Type = typeof(OngFinanceiro))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id) 
    {
        var ongFinanceiro = await _service.PegarPorIdAsync(id);

        if (ongFinanceiro == null) 
            return NotFound();

        return Ok(ongFinanceiro);
    }

    [ProducesResponseType((200), Type = typeof(EditOngFinanceiroModel))]
    [ProducesResponseType((404))]
    [HttpPut("")]
    public async Task<IActionResult> PutAsync(EditOngFinanceiroModel ongFinanceiro)
    {
        if (ongFinanceiro == null)
            return BadRequest();

        var ongFinanceiroEdit = await _service.EditarAsync(ongFinanceiro);

        if (ongFinanceiroEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var ongFinanceiro = await _service.DeletarAsync(id);
        if (ongFinanceiro == false)
            return BadRequest();
            
        return NoContent();
    }

}