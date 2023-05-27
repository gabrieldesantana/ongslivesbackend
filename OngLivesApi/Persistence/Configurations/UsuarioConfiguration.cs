using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ONGLIVES.API.Entidades;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("TB_Usuarios");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
        .HasColumnName("Nome")
        .HasColumnType("nvarchar(100)");

        builder.Property(p => p.Login)
        .HasColumnName("Login")
        .HasColumnType("nvarchar(100)");

        builder.Property(p => p.Senha)
        .HasColumnName("Senha")
        .HasColumnType("");

        builder.Property(p => p.Email)
        .IsRequired()
        .HasColumnName("Email")
        .HasColumnType("nvarchar(100)");

        builder.Property(p => p.Perfil)
        .HasConversion<string>();

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");

        //builder.HasOne(e => e.Endereco)
        //.WithOne()
        //.HasForeignKey<Endereco>(e => e.Id)
        //.IsRequired();
    }
}