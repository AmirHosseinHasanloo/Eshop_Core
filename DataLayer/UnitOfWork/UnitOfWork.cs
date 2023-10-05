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

        private EshopGenericRepository<ProductGroups> _ProductGroupsRepository;

        public EshopGenericRepository<ProductGroups> ProductGroupsRepository
        {
            get
            {
                if (_ProductGroupsRepository == null)
                {
                    _ProductGroupsRepository = new EshopGenericRepository<ProductGroups>(_context);
                }
                return _ProductGroupsRepository;
            }
        }
      
        private EshopGenericRepository<Users> _UsersRepository;

        public EshopGenericRepository<Users> UsersRepository
        {
            get
            {
                if (_ProductGroupsRepository == null)
                {
                    _UsersRepository = new EshopGenericRepository<Users>(_context);
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
