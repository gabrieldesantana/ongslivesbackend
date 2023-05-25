using ONGLIVES.API.Persistence.Context;
using ONGLIVES.API.Repository;

public class OngFinanceiroRepository : GenericRepository<OngFinanceiro>, IOngFinanceiroRepository
{
    public OngFinanceiroRepository(OngLivesContext context, IUnitOfWork unitOfWork) 
    : base(context, unitOfWork)
    {
    }
 
}