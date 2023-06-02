using ONGLIVES.API.Entidades;
using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

public class ImagemRepository : GenericRepository<Imagem>, IImagemRepository
{
    public ImagemRepository(OngLivesContext context, IUnitOfWork unitOfWork)
    : base(context, unitOfWork)
    {
    }
}