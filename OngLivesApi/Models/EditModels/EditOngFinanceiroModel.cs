using ONGLIVES.API.Entidades;

public class EditOngFinanceiroModel 
{
        public int Id { get; set; }
        public int IdOng {get; set;}
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
        public string? Origem { get; set; }
}