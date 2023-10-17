using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IFeatures
    {
        IEnumerable<Feature> GetAllFeatures();
        void AddFeature(Feature feature);
        void EditFeature(Feature feature);
        void DeleteFeature(Feature feature);
        Feature GetFeatureById(int id);
    }
}
