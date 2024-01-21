using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IFeaturesService
    {
        IEnumerable<Feature> GetAllFeatures();
        IEnumerable<Feature> GetFeaturesByProductId(int productId);
        IEnumerable<ProductFeature> GetProductFeaturesByProductId(int productId);
        IEnumerable<string> GetValueOfFeatures(int productId,int featureId);
        void AddFeature(Feature feature);
        void EditFeature(Feature feature);
        void DeleteFeature(Feature feature);
        Feature GetFeatureById(int id);
    }
}
