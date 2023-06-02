using Microsoft.AspNetCore.Mvc;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

namespace ONGLIVES.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
public class VoluntariosController : ControllerBase
{
    private readonly IVoluntarioService _service;
    public VoluntariosController(IVoluntarioService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Voluntario>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetTodosAsync()
    {
        var voluntarios = await _service.PegarTodosAsync();
        return Ok(voluntarios);
    }

    [ProducesResponseType((200), Type = typeof(Voluntario))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id) 
    {
        var voluntario = await _service.PegarPorIdAsync(id);

        if (voluntario == null) 
            return NotFound();

        return Ok(voluntario);
    }

    [ProducesResponseType((200), Type = typeof(Usuario))]
    [ProducesResponseType((404))]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetPorEmailAsync(string email) 
    {
        var voluntario = await _service.PegarPorEmailAsync(email);

        if (voluntario == null) 
            return NotFound();

        return Ok(voluntario);
    }

    [ProducesResponseType((201), Type = typeof(Voluntario))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync(InputVoluntarioModel inputVoluntarioModel)
    {
        if (inputVoluntarioModel == null)
            return BadRequest();

        await _service.CadastrarAsync(inputVoluntarioModel);

        return Ok(inputVoluntarioModel);
    }

    // [ProducesResponseType((201), Type = typeof(Imagem))]
    // [ProducesResponseType((400))]
    // [ProducesResponseType((404))]
    // [HttpPost("{id}/foto")]
    // public async Task<IActionResult> PostFotoAsync(int id, InputImagemModel inputImagemModel)
    // {
    //     var voluntario = await _service.PegarPorIdAsync(id);

    //     if (voluntario == null)
    //         return NotFound();

    //     var imagem = new Imagem 
    //     (
    //     voluntario.Id,
    //     inputImagemModel.Nome,
    //     inputImagemModel.Conteudo
    //     );

    //     if (imagem == null)
    //         return BadRequest();

    //     voluntario.AdicionarFoto(imagem);

    //     await _service.AdicionarFotoAsync(voluntario);

    //     return NoContent();
    // }

    [ProducesResponseType((200), Type = typeof(EditVoluntarioModel))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id,EditVoluntarioModel editVoluntarioModel)
    {
        if (editVoluntarioModel == null)
            return BadRequest();

        var voluntarioEdit = await _service.EditarAsync(id, editVoluntarioModel);

        if (voluntarioEdit == null)
            return BadRequest();

        return NoContent();
    }

    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var voluntario = await _service.DeletarAsync(id);

        if (voluntario == false)
            return BadRequest();
            
        return NoContent();
    }

}