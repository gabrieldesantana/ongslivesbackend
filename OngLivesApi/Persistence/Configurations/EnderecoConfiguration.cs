using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("TB_Enderecos");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.EnderecoLinha)
        .HasColumnType("VARCHAR(100)")
        .IsRequired();

        builder.Property(p => p.Numero)
        .HasColumnType("INT")
        .IsRequired();

        builder.Property(p => p.Cep)
        .HasColumnType("CHAR(8)")
        .IsRequired();

        builder.Property(p => p.Bairro)
        .HasColumnType("VARCHAR(50)")
        .IsRequired();

        builder.Property(p => p.Cidade)
        .HasColumnType("VARCHAR(50)")
        .HasMaxLength(60)
        .IsRequired();

        builder.Property(p => p.Estado)
        .HasColumnType("CHAR(2)")
        .IsRequired();

        builder.Property(p => p.Pais)
        .HasColumnType("VARCHAR(30)")
        .IsRequired();
    }
}