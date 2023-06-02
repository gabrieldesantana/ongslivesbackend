using ONGLIVES.API.Entidades;

public class InputExperienciaModel 
{
        public string? NomeVoluntario { get; set; }
        public string? NomeOng { get; set; }
        public string? ProjetoEnvolvido { get; set; }
        public string? Opiniao { get; set; }
        public int Nota { get; set; }
        public DateTime DataExperienciaInicio{ get; set; }
        public DateTime DataExperienciaFim { get; set; }
}