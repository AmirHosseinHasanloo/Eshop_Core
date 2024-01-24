using Core.Generators;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SliderService : ISliderService
    {
        private EshopContext _context;

        public SliderService(EshopContext context)
        {
            _context = context;
        }

        public void AddSlider(Slider slider, IFormFile image)
        {
            slider.ImageName = SaveFiles(image, "SliderPics");

            _context.Add(slider);
            _context.SaveChanges();
        }

        public void UpdateSlider(int sliderId, IFormFile image)
        {
            var slider = GetSliderById(sliderId);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
              "wwwroot/SliderPics", slider.ImageName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            slider.ImageName = SaveFiles(image, "SliderPics");
            _context.Update(slider);
            _context.SaveChanges();
        }

        public IEnumerable<Slider> GetAllSliders()
        {
            return _context.Sliders.ToList();
        }


        public string SaveFiles(IFormFile file, string path)
        {
            string fileName = GenerateFileNameWithPath(file);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/" + path, fileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
        public string GenerateFileNameWithPath(IFormFile file)
        {
            return NameGenerator.Generate() + Path.GetExtension(file.FileName);
        }

        public Slider GetSliderById(int id)
        {
            return _context.Sliders.Find(id);
        }

        public void RemoveSlider(int id)
        {
            var slider = GetSliderById(id);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
              "wwwroot/SliderPics", slider.ImageName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }
    }
}
