namespace WebServicesAgriPure.AgriPure.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
