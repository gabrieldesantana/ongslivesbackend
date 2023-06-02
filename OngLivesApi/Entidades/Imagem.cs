using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ONGLIVES.API.Entidades
{
    [Table("TB_Imagens")]
    public class Imagem : Base
    {
        public Imagem()
        {
            
        }
        public Imagem(int idDono, string? nome,
         byte[]? conteudo)
        {
            Id = 0;
            IdDono = (idDono != null) ? idDono : 0;
            Nome = nome;
            Conteudo = conteudo;
            CriadoEm = DateTime.Now;
            Actived = true;
        }

        public int IdDono { get; set; }
        public string? Nome { get; set; }
        public byte[]? Conteudo { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Actived { get; set; }
    }
}
