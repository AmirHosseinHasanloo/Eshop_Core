using Core.DTOs;
using Core.Generators;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        EshopContext _context;

        public ProductRepository(EshopContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product, List<int> groups, string tags, IFormFile imagename)
        {
            if (imagename != null)
            {
                string path = "";
                if (imagename.FileName != "no-image.png")
                {
                    product.ImageName = NameGenerator.Generate() + Path.GetExtension(imagename.FileName);
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage", product.ImageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        imagename.CopyTo(stream);
                    }
                }
            }
            product.CreateDate = DateTime.Now;
            _context.Add(product);
            _context.SaveChanges();
            // insert selected group
            AddProductSelectedGroups(product.ProductId, groups);

            // insert tags
            AddProductTags(product.ProductId, tags);

        }


        public void UpdateProduct(Product product, List<int> groups, string tags, IFormFile imagename)
        {
            if (imagename != null)
            {
                string path = "";
                if (imagename.FileName != "no-image.png")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage", product.ImageName);

                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }

                product.ImageName = NameGenerator.Generate() + Path.GetExtension(imagename.FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage", product.ImageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imagename.CopyTo(stream);
                }
            }
            _context.Update(product);
            _context.SaveChanges();

            // Update Product Selected Groups
            UpdateProductSelectedGroups(product.ProductId, groups);

            // Update Product Tags
            UpdateProductTags(product.ProductId, tags);
        }


        public void AddProductSelectedGroups(int productid, List<int> groupid)
        {
            foreach (var group in groupid)
            {
                _context.SelectedGroups.Add(new SelectedGroup()
                {
                    ProductId = productid,
                    GroupId = group,
                });
                _context.SaveChanges();
            }
        }

        public void AddProductTags(int productid, string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                string[] Tags = tag.Split(',');

                foreach (string Tag in Tags)
                {
                    _context.ProductTags.Add(new ProductTag
                    {
                        ProductId = productid,
                        Tag = Tag.Trim(),
                    });
                }
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<ProductGroup> GetAllProductGroups(int productid)
        {
            var SelectedGroups = _context.SelectedGroups.Where(G => G.ProductId == productid).ToList();

            // return this 

            List<ProductGroup> SelectedList = new List<ProductGroup>();

            foreach (var group in SelectedGroups)
            {

                var Add = _context.ProductGroups.Where(G => G.GroupId == group.GroupId);

                foreach (var Adding in Add)
                {
                    SelectedList.Add(Adding);
                }

            }

            return SelectedList.ToList();
        }

        public Product GetProductById(int productid)
        {
            return _context.Products.Find(productid);
        }

        public string GetTagsForShowingInEditProductOnAdmin(int productid)
        {
            return string.Join(",", _context.ProductTags.Where(T => T.ProductId == productid).Select(T => T.Tag).ToList());
        }

        public void UpdateProductTags(int productid, string tag)
        {
            _context.ProductTags.Where(T => T.ProductId == productid).ToList()
                .ForEach(T => _context.ProductTags.Remove(T));

            AddProductTags(productid, tag);
        }

        public void UpdateProductSelectedGroups(int productid, List<int> groupid)
        {
            _context.SelectedGroups.Where(SG => SG.ProductId == productid).ToList()
                .ForEach(SG => _context.SelectedGroups.Remove(SG));

            AddProductSelectedGroups(productid, groupid);
        }

        public List<Feature> GetAllFeatures()
        {
            return _context.Features.ToList();
        }

        public List<ProductFeature> GetProductFeaturesByProductId(int productid)
        {
            return _context.ProductFeatures.Where(PF => PF.ProductId == productid).ToList();
        }

        public void AddProductFeature(ProductFeature productFeature)
        {
            _context.ProductFeatures.Add(new ProductFeature
            {
                Product = productFeature.Product,
                Feature = productFeature.Feature,
                FeatureId = productFeature.FeatureId,
                ProductId = productFeature.ProductId,
                Value = productFeature.Value
            });

            _context.SaveChanges();
        }

        public void DeleteFeature(ProductFeature productFeature)
        {
            _context.ProductFeatures.Remove(productFeature);
            _context.SaveChanges();
        }

        public ProductFeature GetProductFeatureByid(int productfeatureid)
        {
            return _context.ProductFeatures.Where(g => g.ProductFeatureId == productfeatureid).FirstOrDefault();
        }

        public List<ProductGallery> GetProductGalleriesByProductId(int productid)
        {
            return _context.ProductGalleries.Where(PG => PG.ProductId == productid).ToList();
        }

        public void AddProductGallery(ProductGallery productgallery, IFormFile imagename)
        {
            dynamic FilePath;
            if (imagename != null)
            {
                productgallery.ImageName = NameGenerator.Generate() + Path.GetExtension(imagename.FileName);

                FilePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/ProductImage/ProductGalleries",
                productgallery.ImageName
                                      );

                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    imagename.CopyTo(stream);
                }

                _context.ProductGalleries.Add(productgallery);
                _context.SaveChanges();
            }

        }

        public ProductGallery GetProductGalleryById(int galleryid)
        {
            return _context.ProductGalleries.Find(galleryid);
        }

        public void DeleteProductGallery(int galleryid)
        {
            var Delete = GetProductGalleryById(galleryid);



            if (Delete.ImageName != null)
            {
                string FilePath = Path.Combine
                (Directory.GetCurrentDirectory(),
                "wwwroot/ProductImage/ProductGalleries",
                Delete.ImageName);

                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }

            _context.ProductGalleries.Remove(Delete);
            _context.SaveChanges();
        }
    }
}