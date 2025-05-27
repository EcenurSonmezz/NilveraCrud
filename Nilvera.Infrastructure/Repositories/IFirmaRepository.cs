using Nilvera.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nilvera.Infrastructure.Repositories
{
    public interface IFirmaRepository
    {
        Task<int> InsertAsync(Firma firma);
        Task<Firma> GetByIdAsync(int id);
        Task<IEnumerable<Firma>> GetAllAsync();
        Task<int> UpdateAsync(Firma firma);
        Task<int> DeleteAsync(int id);
    }
}
