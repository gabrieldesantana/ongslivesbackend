using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class ImagemService : IImagemService
{
    private readonly IImagemRepository _repository;
    public ImagemService(IImagemRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Imagem>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Imagem> PegarPorIdAsync(int id)
    {
        var imagem = await _repository.PegarPorIdAsync(id);

        if (imagem == null) return null;

        return imagem;
    }

    public async Task<Imagem> CadastrarAsync(InputImagemModel inputImagemModel)
    {
        if (inputImagemModel == null)
            throw new Exception("Imagem sem informacoes");

        var imagem = new Imagem 
        (
        inputImagemModel.IdDono,
        inputImagemModel.Nome,
        inputImagemModel.Conteudo
        );

        await _repository.CadastrarAsync(imagem);
        
        return imagem;
    }

    public async Task<Imagem> EditarAsync(int id, EditImagemModel editImagemModel)
    {
        var imagemEdit = await _repository.PegarPorIdAsync(id);

        if (imagemEdit == null) return null;

        imagemEdit.Id = id;
        imagemEdit.Nome = editImagemModel.Nome;

        imagemEdit = await _repository.EditarAsync(imagemEdit);

        return imagemEdit;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var imagem = await _repository.PegarPorIdAsync(id);

        if (imagem == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }
}