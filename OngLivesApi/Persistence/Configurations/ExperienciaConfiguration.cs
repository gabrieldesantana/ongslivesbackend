using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class ExperienciaConfiguration : IEntityTypeConfiguration<Experiencia>
{
    public void Configure(EntityTypeBuilder<Experiencia> builder)
    {
        builder.ToTable("TB_Experiencias");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.IdVoluntario)
        .HasColumnName("IdVoluntario")
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.IdOng)
        .HasColumnName("IdOng")
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.NomeVoluntario)
        .HasColumnName("NomeVoluntario")
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("nvarchar(100)");

        builder.Property(e => e.NomeOng)
        .HasColumnName("NomeOng")
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("nvarchar(100)");

        builder.Property(e => e.ProjetoEnvolvido)
        .HasColumnName("ProjetoEnvolvido")
        .HasColumnType("nvarchar(max)");

        builder.Property(p => p.Opiniao)
        .HasColumnName("ProjetoEnvolvido")
        .HasColumnType("nvarchar(max)");

        builder.Property(p => p.DataPostagem)
        .HasColumnName("DataPostagem")
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(p => p.DataExperienciaInicio)
        .HasColumnName("DataExperienciaInicio")
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(p => p.DataExperienciaFim)
        .HasColumnName("DataExperienciaFim")
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

    }
}