using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

public class VagaRepository : GenericRepository<Vaga>, IVagaRepository
{
    public VagaRepository(OngLivesContext context, IUnitOfWork unitOfWork)
    : base(context, unitOfWork)
    {
    }
}