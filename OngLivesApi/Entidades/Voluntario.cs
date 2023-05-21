using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ONGLIVES.API.Entidades
{
    public class Voluntario : Base
    {
        public Voluntario()
        {
        }
        public Voluntario(
            string? nome,
            string? cpf,
            DateTime dataNascimento,
            string? escolaridade,
            string? genero,
            string? email,
            string? telefone,
            string? habilidade,
            double avaliacao,
            int horasVoluntaria,
            int quantidadeExperiencias,
            Endereco? endereco
            )
        {
            Nome = nome?.ToUpper();
            CPF = cpf;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Genero = genero;
            Email = email;
            Telefone = telefone;
            Habilidade = habilidade;
            Avaliacao = avaliacao;
            HorasVoluntaria = horasVoluntaria;
            QuantidadeExperiencias = quantidadeExperiencias;
            Endereco = endereco;
            CriadoEm = DateTime.Now;
        }
        
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Escolaridade { get; set; }
        public string? Genero { get; set; }
        public string? Email { get; set; }
        public string? Telefone {get; set;}
        public string? Habilidade { get; set; }
        public double Avaliacao {get; set;}
        public int HorasVoluntaria { get; set; }
        public int QuantidadeExperiencias { get; set; }
        public Endereco? Endereco { get; set; }
        [JsonIgnore]
        public DateTime CriadoEm { get; set; }
    }
}