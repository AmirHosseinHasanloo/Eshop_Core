using DataLayer.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class UnitOfWork : IDisposable
    {
        EshopContext _context;

        public UnitOfWork(EshopContext context)
        {
            _context = context;
        }

        private EshopGenericRepository<ProductGroup> _ProductGroupsRepository;

        public EshopGenericRepository<ProductGroup> ProductGroupsRepository
        {
            get
            {
                if (_ProductGroupsRepository == null)
                {
                    _ProductGroupsRepository = new EshopGenericRepository<ProductGroup>(_context);
                }
                return _ProductGroupsRepository;
            }
        }
      
        private EshopGenericRepository<User> _UsersRepository;

        public EshopGenericRepository<User> UsersRepository
        {
            get
            {
                if (_ProductGroupsRepository == null)
                {
                    _UsersRepository = new EshopGenericRepository<User>(_context);
                }
                return _UsersRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
