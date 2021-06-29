using System.Threading.Tasks;
using Twenty.Data.Domain;

namespace Twenty.Data.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> GetCoolestCategory();
    }
}