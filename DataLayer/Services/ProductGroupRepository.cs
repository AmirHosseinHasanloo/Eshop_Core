using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace DataLayer.Services
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private EshopContext _context;

        public ProductGroupRepository(EshopContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGroups(ProductGroup group)
        {
            if (group == null)
            {
                return false;
            }

            _context.ProductGroups.Add(group);
            await _context.SaveChangesAsync();
            return true;
        }

        public void DeleteGroups(int groupid)
        {
            var GroupsList = _context.ProductGroups.ToList();
            var group = GetById(groupid);

            if (GroupsList.Any(G => G.ParentId == groupid))
            {
                foreach (var delete in GroupsList.Where(G => G.ParentId == groupid))
                {
                    _context.ProductGroups.Remove(delete);
                }

                _context.SaveChanges();
            }

            _context.ProductGroups.Remove(group);
            _context.SaveChanges();
        }

        public async Task<List<ProductGroup>> GetAllGroupsAsync()
        {
            return await _context.ProductGroups.ToListAsync();
        }

        public ProductGroup GetById(int id)
        {
            return _context.ProductGroups.Find(id);
        }

        public bool UpdateGroups(ProductGroup group)
        {

            if (group == null)
            {
                return false;
            }

            _context.ProductGroups.Update(group);
            _context.SaveChanges();
            return true;
        }
    }
}
