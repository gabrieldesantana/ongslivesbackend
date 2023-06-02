using ONGLIVES.API.Entidades;

public class EditVagaModel 
{
        public int Id {get; set;}
        
        public string? Tipo {get; set;}
        public string? Turno {get; set;}
        public string? Descricao {get; set;}  
        public string? Habilidade {get; set;}
        public bool Disponivel { get; set; }
        public DateTime DataInicio {get; set;}
        public DateTime DataFim {get; set;}
}