using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ISliderService
    {
        IEnumerable<Slider> GetAllSliders();
        Slider GetSliderById(int id);
        void AddSlider(Slider slider, IFormFile image);
        void UpdateSlider(int sliderId, IFormFile image);
        void RemoveSlider(int id);
        string SaveFiles(IFormFile file, string path);
        string GenerateFileNameWithPath(IFormFile file);
    }
}
