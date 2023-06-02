using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class ImagemConfiguration : IEntityTypeConfiguration<Imagem>
{
    public void Configure(EntityTypeBuilder<Imagem> builder)
    {
        builder.ToTable("TB_Imagens");

        builder.HasKey(x => x.Id);

        builder.Property(e => e.IdDono)
        .HasColumnName("IdDono")
        .HasColumnType("int");

        builder.Property(e => e.Nome)
        .HasColumnName("Nome")
        .HasColumnType("nvarchar(100)");

        builder.Property(e => e.Conteudo)
        .HasColumnName("Conteudo");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    }
}