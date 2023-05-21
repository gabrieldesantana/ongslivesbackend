using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class VagaConfiguration : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.ToTable("TB_Vagas");
        builder.HasKey(x => x.Id);

        builder.Property(e => e.IdVoluntario)
        .HasColumnName("IdVoluntario")
        .HasColumnType("int");

        builder.Property(e => e.IdOng)
        .HasColumnName("IdOng")
        .IsRequired()
        .HasColumnType("int");

        builder.Property(p => p.Tipo)
        .HasColumnName("Tipo")
        .IsRequired()
        .HasColumnType("nvarchar(50)");

        builder.Property(p => p.Turno)
        .HasColumnName("Turno")
        .HasColumnType("nvarchar(50)");

        builder.Property(p => p.Descricao)
        .IsRequired()
        .HasColumnName("Descricao")
        .HasColumnType("nvarchar(max)");

        builder.Property(p => p.Habilidade)
        .IsRequired()
        .HasColumnName("Habilidade")
        .HasColumnType("nvarchar(max)");

        builder.Property(p => p.DataInicio)
        .HasColumnName("DataInicio")
        .HasColumnType("datetime");

        builder.Property(p => p.DataFim)
        .HasColumnName("DataFim")
        .HasColumnType("datetime");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");


        builder.HasOne(p => p.Voluntario)
        .WithOne()
        .HasForeignKey<Voluntario>(e => e.Id)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Ong)
        .WithOne()
        .HasForeignKey<Voluntario>(e => e.Id)
        .OnDelete(DeleteBehavior.Restrict);

    }
}