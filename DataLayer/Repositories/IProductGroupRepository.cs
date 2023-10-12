using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IProductGroupRepository
    {
        Task<List<ProductGroup>> GetAllGroupsAsync();
        ProductGroup GetById(int id);
        Task<bool> AddGroups(ProductGroup group);
        bool UpdateGroups(ProductGroup group);

        void DeleteGroups(int groupid);
    }
}
