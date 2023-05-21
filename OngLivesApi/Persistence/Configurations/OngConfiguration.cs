using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class OngConfiguration : IEntityTypeConfiguration<Ong>
{
    public void Configure(EntityTypeBuilder<Ong> builder)
    {
        builder.ToTable("TB_Ongs");
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
        .HasColumnName("Nome")
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnType("nvarchar(100)");

        builder.Property(p => p.CNPJ)
        .HasColumnName("CNPJ")
        .HasMaxLength(18)
        .HasColumnType("nvarchar(18)")
        .IsRequired();

        builder.Property(p => p.Telefone)
        .HasColumnName("Telefone")
        .HasMaxLength(14)
        .HasColumnType("nvarchar(14)")
        .IsRequired();

        builder.Property(p => p.Email)
        .HasColumnName("Email")
        .HasMaxLength(50)
        .HasColumnType("nvarchar(50)")
        .IsRequired();

        builder.Property(p => p.AreaAtuacao)
        .HasColumnName("AreaAtuacao")
        .HasMaxLength(50)
        .HasColumnType("nvarchar(50)")
        .IsRequired();

        builder.Property(p => p.QuantidadeEmpregados)
        .HasColumnName("QuantEmpregados")
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        builder.HasMany(p => p.Financeiros)
        .WithOne()
        .HasForeignKey(p => p.Id)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Endereco)
        .WithOne()
        .HasForeignKey<Endereco>(p => p.Id)
        .IsRequired();

        builder.HasMany(p => p.Vagas)
        .WithOne()
        .HasForeignKey(p => p.Id)
        .OnDelete(DeleteBehavior.Restrict);
    }
}