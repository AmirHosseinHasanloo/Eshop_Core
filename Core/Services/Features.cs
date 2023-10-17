using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class Features : IFeatures
    {
        EshopContext _context;

        public Features(EshopContext context)
        {
            _context = context;
        }

        public void AddFeature(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
        }

        public void DeleteFeature(Feature feature)
        {
            _context.Features.Remove(feature);
            _context.SaveChanges();
        }

        public void EditFeature(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
        }

        public IEnumerable<Feature> GetAllFeatures()
        {
            return _context.Features.ToList();
        }

        public Feature GetFeatureById(int id)
        {
            return _context.Features.Find(id);
        }
    }
}
