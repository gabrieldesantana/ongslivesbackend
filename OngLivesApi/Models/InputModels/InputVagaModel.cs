using ONGLIVES.API.Entidades;

public class InputVagaModel 
{
        public int IdVoluntario { get; set; }
        public int IdOng { get; set; }

        public string? Tipo { get; set; }
        public string? Turno { get; set; }
        public string? Descricao { get; set; }
        public string? Habilidade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
}