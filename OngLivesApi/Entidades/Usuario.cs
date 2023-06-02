using ONGLIVES.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONGLIVES.API.Entidades
{
    [Table("TB_Usuarios")]
    public class Usuario : Base
    {
        public Usuario(
           string? nome,
           string? login,
           string? senha,
           string? email,
           EPerfilUsuario? perfil, bool actived)
        {
           Nome = nome;
           Login = login;
           Senha = senha;
           Email = email;
           Perfil = perfil;
           CriadoEm = DateTime.Now;
           Actived = actived;
        }
        public string? Nome { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Email { get; set; }
        public EPerfilUsuario? Perfil { get; set; }
        public DateTime? CriadoEm { get; set; }

        public bool SenhaValida(string senha) => this.Senha == senha;
    }
}
