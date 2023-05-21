using ONGLIVES.API.Entidades;

public class EditVoluntarioModel 
{
        public int Id { get; set; }
        public string? Escolaridade { get; set; }
        public string? Email { get; set; }
        public string? Telefone {get; set;}
        public string? Habilidade { get; set; }
        public double Avaliacao {get; set;}
        public int HorasVoluntaria { get; set; }
        public int QuantidadeExperiencias { get; set; }
        public Endereco? Endereco { get; set; }
}