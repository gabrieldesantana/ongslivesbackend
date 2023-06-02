using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ONGLIVES.API.Entidades;

namespace ONGLIVES.API.Entidades;
[Table("TB_OngFinanceiros")]
public class OngFinanceiro : Base
{
    public OngFinanceiro()
    { 
    }
    public OngFinanceiro(
        int idOng,
        string? tipo,
        DateTime data,
        decimal valor,
        string? origem)
    {
        IdOng = idOng;
        Tipo = tipo;
        Data = data;
        Valor = valor;
        Origem = origem;
        CriadoEm = DateTime.Now;
    }

    public int IdOng {get; set;}
    public string? Tipo { get; set; }
    public DateTime Data{ get; set; }
    public decimal Valor { get; set; }
    public string? Origem { get; set; }
    [JsonIgnore]
    public DateTime CriadoEm { get; set; }
}