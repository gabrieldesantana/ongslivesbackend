using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Interfaces;

public interface IImagemService
{
    public Task<List<Imagem>> PegarTodosAsync();
    public Task<Imagem> PegarPorIdAsync(int id);
    public Task<Imagem> CadastrarAsync(InputImagemModel inputImagemModel);
    public Task<Imagem> EditarAsync(int id, EditImagemModel editImagemModel);
    public Task<bool> DeletarAsync(int id);

}