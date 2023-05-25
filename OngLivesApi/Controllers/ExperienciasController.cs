using Microsoft.AspNetCore.Mvc;
using ONGLIVES.API.Entidades;
using ONGLIVESAPI.Interfaces;

namespace ONGLIVES.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
public class ExperienciasController : ControllerBase
{
    private readonly IExperienciaService _service;
    public ExperienciasController(IExperienciaService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Experiencia>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetTodosAsync()
    {
        var experiencias = await _service.PegarTodosAsync();
        return Ok(experiencias);
    }

    [ProducesResponseType((200), Type = typeof(Experiencia))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id) 
    {
        var experiencia = await _service.PegarPorIdAsync(id);

        if (experiencia == null) 
            return NotFound();

        return Ok(experiencia);
    }

    [ProducesResponseType((201), Type = typeof(Experiencia))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync(InputExperienciaModel inputExperienciaModel)
    {
        if (inputExperienciaModel == null)
            return BadRequest();
            
        await _service.CadastrarAsync(inputExperienciaModel);

        return Ok(inputExperienciaModel);
    }


    [ProducesResponseType((200), Type = typeof(EditExperienciaModel))]
    [ProducesResponseType((404))]
    [HttpPut("")]
    public async Task<IActionResult> PutAsync(EditExperienciaModel editExperienciaModel)
    {
        if (editExperienciaModel == null)
            return BadRequest();

        var experienciaEdit = await _service.EditarAsync(editExperienciaModel);

        if (experienciaEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var experiencia = await _service.DeletarAsync(id);
        if (experiencia == false)
            return BadRequest();
            
        return NoContent();
    }

}