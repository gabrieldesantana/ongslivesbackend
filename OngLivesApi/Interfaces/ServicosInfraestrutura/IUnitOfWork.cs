using ONGLIVES.API.Entidades;
using ONGLIVES.API.Interfaces.ServicosInfraestrutura;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
}