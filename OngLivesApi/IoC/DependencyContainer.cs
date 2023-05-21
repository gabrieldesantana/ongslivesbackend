using ONGLIVES.API.Interfaces.ServicosInfraestrutura;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;
using ONGLIVESAPI.Interfaces;

public static class DependecyContainer 
{
    public static void AddRegisterServices(this IServiceCollection services)
    {
        #region Context
            services.AddScoped<OngLivesContext>();
        #endregion

        #region Services
            services.AddScoped<IOngService,OngService>();
            services.AddScoped<IOngFinanceiroService,OngFinanceiroService>();
            services.AddScoped<IVoluntarioService,VoluntarioService>();
            services.AddScoped<IVagaService,VagaService>();
            services.AddScoped<IExperienciaService, ExperienciaService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Repository
            services.AddScoped<IOngRepository,OngRepository>();
            services.AddScoped<IOngFinanceiroRepository, OngFinanceiroRepository>();
            services.AddScoped<IVoluntarioRepository,VoluntarioRepository>();
            services.AddScoped<IVagaRepository,VagaRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        #endregion
    }
}