using ONGLIVES.API.Entidades;

public class InputImagemModel 
{
    public int Id { get; set; }
    public int IdDono { get; set; }
    public string? Nome { get; set; }
    public byte[]? Conteudo { get; set; }
}