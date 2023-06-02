using ONGLIVES.API.Enums;

public class EditUsuarioModel 
{
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario? Perfil { get; set; }
        public bool Actived { get; set; }
        // public DateTime? CriadoEm { get; set; }
}