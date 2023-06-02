using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class VoluntarioConfiguration : IEntityTypeConfiguration<Voluntario>
{
    public void Configure(EntityTypeBuilder<Voluntario> builder)
    {
        builder.ToTable("TB_Voluntarios");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.Nome)
        .HasColumnName("Nome")
        .IsRequired()
        .HasColumnType("nvarchar(100)");

        builder.Property(e => e.CPF)
        .HasColumnName("CPF")
        .IsRequired()
        .HasColumnType("nvarchar(14)");

        builder.Property(p => p.DataNascimento)
        .HasColumnName("DataNascimento")
        .IsRequired()
        .HasColumnType("date");

        builder.Property(p => p.Escolaridade)
        .HasColumnName("Escolaridade")
        .HasColumnType("nvarchar(50)");

        builder.Property(p => p.Genero)
        .HasColumnName("Genero")
        .HasColumnType("nvarchar(20)");

        builder.Property(p => p.Email)
        .HasColumnName("Email")
        .IsRequired()
        .HasColumnType("nvarchar(100)");

        builder.Property(p => p.Telefone)
        .IsRequired()
        .HasColumnName("Telefone")
        .HasColumnType("nvarchar(14)");

        builder.Property(e => e.Habilidade)
        .HasColumnName("Habilidade")
        .IsRequired()
        .HasColumnType("nvarchar(max)");

        builder.Property(e => e.Avaliacao)
        .HasColumnName("Avaliacao")
        .HasColumnType("float");

        builder.Property(p => p.HorasVoluntaria)
        .HasColumnName("HorasVoluntaria")
        .HasColumnType("int");

        builder.Property(p => p.QuantidadeExperiencias)
        .HasColumnName("QuantidadeExperiencias")
        .HasColumnType("int");

        // builder.Property(p => p.Imagem.Id)
        // .HasColumnName("ImagemId")
        // .IsRequired()
        // .HasColumnType("int");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        // builder.HasOne(p => p.Imagem)
        // .WithOne()
        // .HasForeignKey<Imagem>(p => p.Id)
        // .IsRequired();

        builder.HasOne(e => e.Endereco)
        .WithOne()
        .HasForeignKey<Endereco>(e => e.Id)
        .IsRequired();
    }
}