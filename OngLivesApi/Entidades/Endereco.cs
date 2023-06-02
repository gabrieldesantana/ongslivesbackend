using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ONGLIVES.API.Entidades
{
    [Table("TB_Enderecos")]
    public class Endereco
    {
        public Endereco()
        {
        }
        
        [JsonIgnore]
        public int Id { get; set; }
        public string? EnderecoLinha { get; set; }
        public int Numero {get; set;}
        public string? Cep { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Pais { get; set; }
        public string? Latitude { get; set; } = "0";
        public string? Longitude { get; set; } = "0";
    }
}