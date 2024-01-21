using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class FeaturesService : IFeaturesService
    {
        EshopContext _context;

        public FeaturesService(EshopContext context)
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

        public IEnumerable<Feature> GetFeaturesByProductId(int productId)
        {
            return _context.ProductFeatures
                .Include(pf => pf.Feature)
                .Where(pf => pf.ProductId == productId)
                .Select(pf => new Feature
                {
                    FeatureId = pf.FeatureId,
                    FeatureTitle = pf.Feature.FeatureTitle,
                }).ToList();
        }

        public IEnumerable<ProductFeature> GetProductFeaturesByProductId(int productId)
        {
            return _context.ProductFeatures
                .Include(pf => pf.Product)
                .Where(pf => pf.ProductId == productId).ToList();
        }

        public IEnumerable<string> GetValueOfFeatures(int productId, int featureId)
        {
            return _context.ProductFeatures
                .Where(pf => pf.ProductId == productId && pf.FeatureId == featureId)
                .Select(pf => pf.Value).ToList().Distinct();
        }
    }
}
