using DataLayer.Generic_Repository;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

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
                if (_UsersRepository == null)
                {
                    _UsersRepository = new EshopGenericRepository<User>(_context);
                }
                return _UsersRepository;
            }
        }


        private EshopGenericRepository<Feature> _FeaturesRepository;

        public EshopGenericRepository<Feature> FeaturesRepository
        {
            get
            {
                if (_FeaturesRepository == null)
                {
                    _FeaturesRepository = new EshopGenericRepository<Feature>(_context);
                }
                return _FeaturesRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
