using Microsoft.EntityFrameworkCore.Storage;

namespace TastyTrails.API.Repositories.Interfaces
{
    public interface ITransactionManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}
