using Microsoft.EntityFrameworkCore;
using ONGLIVES.API.Entidades;
namespace ONGLIVES.API.Persistence.Context
{
    public class OngLivesContext : DbContext
    {
        public OngLivesContext(DbContextOptions<OngLivesContext> options) : base(options)
        {
        }

        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<OngFinanceiro> OngFinanceiros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagem> TB_Imagens {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=sv-gsgomes.database.windows.net;DataBase=DB_OngsLives;User Id=gsgomes;Password=Biel0707");
            
            //optionsBuilder.UseSqlServer("Server=GSGOMES-DESKTOP\\SQLEXPRESS;DataBase=DB_OngsLives;Integrated Security=SSPI;TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer("Server=sv-ongslives.database.windows.net;DataBase=BD_OngsLives;User Id=ongslivesdba;Password=Ongs0707");
            optionsBuilder.UseSqlServer("Server=sv-ongslives.database.windows.net;Initial Catalog=BD_ONGSLIVES;Persist Security Info=False;User ID=ongslivesdba;Password=Ongs0707;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}