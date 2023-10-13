using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IProductRepository
    {
        void AddProductTags(int productid, string tag);
        void AddProductSelectedGroups(int productid, List<int> groupid);
    }
}
