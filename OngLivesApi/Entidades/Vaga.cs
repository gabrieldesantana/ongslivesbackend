using System.Text.Json.Serialization;

namespace ONGLIVES.API.Entidades
{
    public class Vaga : Base
    {
        public Vaga()
        {
        }
        public Vaga(
            int idVoluntario,
            int idOng,
            string? tipo,
            string? turno,
            string? descricao,
            string? habilidade,
            DateTime dataInicio,
            DateTime dataFim)
        {
            IdVoluntario = idVoluntario;
            IdOng = idOng;
            Tipo = tipo;
            Turno = turno;
            Descricao = descricao;
            Habilidade = habilidade;
            DataInicio = dataInicio;
            DataFim = dataFim;
            CriadoEm = DateTime.Now;
        }

        public int IdVoluntario { get; set; }
        public Voluntario? Voluntario { get; set; }
        
        public int IdOng { get; set; }
        public Ong? Ong { get; set; }
        
        public string? Tipo { get; set; }
        public string? Turno { get; set; }
        public string? Descricao { get; set; }
        public string? Habilidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        [JsonIgnore]
        public DateTime CriadoEm { get; set; }
    }
}