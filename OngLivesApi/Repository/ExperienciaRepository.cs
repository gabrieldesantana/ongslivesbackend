using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

public class ExperienciaRepository : GenericRepository<Experiencia>, IExperienciaRepository
{
    public ExperienciaRepository(OngLivesContext context, IUnitOfWork unitOfWork) 
    : base(context, unitOfWork)
    {
        
    }
}