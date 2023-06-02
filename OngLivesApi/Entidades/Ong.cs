using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ONGLIVES.API.Entidades
{
    [Table("TB_Ongs")]
    public class Ong : Base
    {
        public Ong()
        {
        }
        
        public Ong(
            string? nome,
            string? cnpj,
            string? telefone,
            string? email,
            string? areaAtuacao,
            int quantidadeEmpregados,
            Endereco? endereco)
        {
            Nome = nome?.ToUpper();
            CNPJ = cnpj;
            Telefone = telefone;
            Email = email;
            AreaAtuacao = areaAtuacao;
            QuantidadeEmpregados = quantidadeEmpregados;
            Vagas = new List<Vaga>();
            Financeiros = new List<OngFinanceiro>();
            // Imagem = new Imagem();
            Endereco = endereco;
            CriadoEm = DateTime.Now;
        }

        public void AdicionarVaga(Vaga vaga)
        {
            Vagas.Add(vaga);
        }

        // public void AdicionarFoto(Imagem imagem)
        // {
        //     Imagem = imagem;
        // }

        public void AdicionarFinanceiro(OngFinanceiro ongFinanceiro)
        {
            Financeiros.Add(ongFinanceiro);
        }
        
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? AreaAtuacao { get; set; }
        public int QuantidadeEmpregados { get; set; }
        public List<Vaga>? Vagas { get; set; }
        public List<OngFinanceiro> Financeiros { get; set; }
        // public Imagem Imagem { get; set; }
        public Endereco? Endereco { get; set; }
        [JsonIgnore]
        public DateTime CriadoEm { get; set; }
    }
}