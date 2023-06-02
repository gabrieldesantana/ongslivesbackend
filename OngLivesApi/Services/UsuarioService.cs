using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Usuario>> PegarTodosAsync()
    {
        return await _repository.PegarTodosAsync();
    }

    public async Task<Usuario> PegarPorIdAsync(int id)
    {
        var usuario = await _repository.PegarPorIdAsync(id);

        if (usuario == null) return null;

        return usuario;
    }

    public async Task<Usuario> PegarPorEmailAsync(string email)
    {
        var usuario = await _repository.PegarPorEmailAsync(email);

        if (usuario == null) return null;

        return usuario;
    }

    public async Task<Usuario> CadastrarAsync(InputUsuarioModel inputUsuarioModel)
    {
        if (inputUsuarioModel == null)
            throw new Exception("Usuario sem informacoes");
        
        var usuarioAtivo = false;

        if (inputUsuarioModel.Perfil == ONGLIVES.API.Enums.EPerfilUsuario.Admin)
        {
            usuarioAtivo = true;
        }

        var usuario = new Usuario 
        (
        inputUsuarioModel.Nome,
        inputUsuarioModel.Login,
        inputUsuarioModel.Senha,
        inputUsuarioModel.Email,
        inputUsuarioModel.Perfil,
        usuarioAtivo
        );

        await _repository.CadastrarAsync(usuario);
        
        return usuario;
    }

    public async Task<Usuario> EditarAsync(int id, EditUsuarioModel editUsuarioModel)
    {
        var usuarioEdit = await _repository.PegarPorIdAsync(id);

        if (usuarioEdit == null) return null;

        usuarioEdit.Id = id;
        usuarioEdit.Nome = editUsuarioModel.Nome;
        usuarioEdit.Email = editUsuarioModel.Email;
        usuarioEdit.Login = editUsuarioModel.Login;
        usuarioEdit.Senha = editUsuarioModel.Senha;
        usuarioEdit.Perfil = editUsuarioModel.Perfil;
        usuarioEdit.Actived = editUsuarioModel.Actived;

        usuarioEdit = await _repository.EditarAsync(usuarioEdit);

        return usuarioEdit;
    }

    public async Task<bool> UpdateSituationAsync(int id)
    {
        var usuarioEdit = await _repository.PegarPorIdAsync(id);

        if (usuarioEdit == null) return false;

        usuarioEdit.Actived = (usuarioEdit.Actived == true) ? false: true;

        try 
        {
             usuarioEdit = await _repository.EditarAsync(usuarioEdit);
             return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var usuario = await _repository.PegarPorIdAsync(id);

        if (usuario == null) return false;
            
        await _repository.DeletarAsync(id);
        return true;
    }


}