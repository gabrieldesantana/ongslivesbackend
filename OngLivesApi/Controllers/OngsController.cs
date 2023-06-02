using Microsoft.AspNetCore.Mvc;
using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

namespace ONGLIVES.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Route("api/[controller]")]
public class OngsController : ControllerBase
{
    private readonly IOngService _service;
    public OngsController(IOngService service)
    {
        _service = service;
    }

    [ProducesResponseType((200), Type = typeof(List<Voluntario>))]
    [ProducesResponseType((404))]
    [HttpGet("")]
    public async Task<IActionResult> GetTodosAsync()
    {
        var ongs = await _service.PegarTodosAsync();
        return Ok(ongs);
    }
    

    [ProducesResponseType((200), Type = typeof(Voluntario))]
    [ProducesResponseType((404))]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPorIdAsync(int id)
    {
        var ong = await _service.PegarPorIdAsync(id);

        if (ong == null)
            return NotFound();

        return Ok(ong);
    }

    [ProducesResponseType((200), Type = typeof(Usuario))]
    [ProducesResponseType((404))]
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetPorEmailAsync(string email) 
    {
        var ong = await _service.PegarPorEmailAsync(email);

        if (ong == null) 
            return NotFound();

        return Ok(ong);
    }


    [ProducesResponseType((201), Type = typeof(Voluntario))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("")]
    public async Task<IActionResult> PostAsync(InputOngModel inputOngModel)
    {
        if (inputOngModel == null)
            return BadRequest();
        
        await _service.CadastrarAsync(inputOngModel);

        return Ok(inputOngModel);
    }

    [ProducesResponseType((201), Type = typeof(Vaga))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("{id}/vagas")]
    public async Task<IActionResult> PostVagaAsync(int id, InputVagaOngModel inputVagaOngModel)
    {
        var ong = await _service.PegarPorIdAsync(id);

        if (ong == null)
            return NotFound();

        var vaga = new Vaga 
        (
        inputVagaOngModel.IdVoluntario,
        ong.Id,
        inputVagaOngModel.Tipo,
        inputVagaOngModel.Turno,
        inputVagaOngModel.Descricao,
        inputVagaOngModel.Habilidade,
        inputVagaOngModel.DataInicio,
        inputVagaOngModel.DataFim
        );

        if (vaga == null)
            return BadRequest();

        ong.AdicionarVaga(vaga);
        await _service.AdicionarVagaAsync(ong);

        return NoContent();
    }

    [ProducesResponseType((201), Type = typeof(OngFinanceiro))]
    [ProducesResponseType((400))]
    [ProducesResponseType((404))]
    [HttpPost("{id}/financeiros")]
    public async Task<IActionResult> PostFinanceiroAsync(int id, InputOngFinanceiroModel inputOngFinanceiroModel)
    {
        var ong = await _service.PegarPorIdAsync(id);

        if (ong == null)
            return NotFound();

        var ongFinanceiro = new OngFinanceiro 
        (
        ong.Id,
        inputOngFinanceiroModel.Tipo,
        inputOngFinanceiroModel.Data,
        inputOngFinanceiroModel.Valor,
        inputOngFinanceiroModel.Origem
        );

        if (ongFinanceiro == null)
            return BadRequest();

        ong.AdicionarFinanceiro(ongFinanceiro);

        await _service.AdicionarFinanceiroAsync(ong);

        return NoContent();
    }

    // [ProducesResponseType((201), Type = typeof(Imagem))]
    // [ProducesResponseType((400))]
    // [ProducesResponseType((404))]
    // [HttpPost("{id}/foto")]
    // public async Task<IActionResult> PostFotoAsync(int id, InputImagemModel inputImagemModel)
    // {
    //     var ong = await _service.PegarPorIdAsync(id);

    //     if (ong == null)
    //         return NotFound();

    //     var imagem = new Imagem 
    //     (
    //     ong.Id,
    //     inputImagemModel.Nome,
    //     inputImagemModel.Conteudo
    //     );

    //     if (imagem == null)
    //         return BadRequest();

    //     ong.AdicionarFoto(imagem);

    //     await _service.AdicionarFotoAsync(ong);

    //     return NoContent();
    // }


    [ProducesResponseType((200), Type = typeof(Voluntario))]
    [ProducesResponseType((404))]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, EditOngModel ong)
    {
        if (ong == null)
            return BadRequest();

        var OngEdit = await _service.EditarAsync(id, ong);

        if (OngEdit == null)
            return BadRequest();

        return NoContent();
    }


    [ProducesResponseType((200))]
    [ProducesResponseType((400))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var ong = await _service.DeletarAsync(id);
        if (ong == false)
            return BadRequest();
            
        return NoContent();
    }

}