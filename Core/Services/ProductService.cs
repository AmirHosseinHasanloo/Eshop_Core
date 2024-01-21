using Core.DTOs;
using Core.Generators;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public class ProductService : IProductService
    {
        EshopContext _context;

        public ProductService(EshopContext context)
        {
            _context = context;
        }

        #region Add
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
                string[] Tags = tag.Split('-');

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

        public void AddProductComment(ProductComments comment, string userName)
        {
            comment.CreateDate = DateTime.Now;
            comment.UserId = _context.Users.Single(u => u.UserName == userName).UserId;
            _context.ProductComments.Add(comment);
            _context.SaveChanges();
        }

        #endregion

        #region Get 
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
            return _context.Products.Include(p => p.ProductGalleries)
                .Include(p => p.ProductTags)
                .SingleOrDefault(p => p.ProductId == productid);
        }

        public string GetTagsForShowingInEditProductOnAdmin(int productid)
        {
            return string.Join("-", _context.ProductTags.Where(T => T.ProductId == productid).Select(T => T.Tag).ToList());
        }

        public List<Feature> GetAllFeatures()
        {
            return _context.Features.ToList();
        }

        public List<ProductFeature> GetProductFeaturesByProductIdForAdmin(int productid)
        {
            return _context.ProductFeatures.Where(PF => PF.ProductId == productid).ToList();
        }

        public ProductFeature GetProductFeatureByid(int productfeatureid)
        {
            return _context.ProductFeatures.Where(g => g.ProductFeatureId == productfeatureid).FirstOrDefault();
        }

        public List<ProductGallery> GetProductGalleriesByProductId(int productid)
        {
            return _context.ProductGalleries.Where(PG => PG.ProductId == productid).ToList();
        }

        public ProductGallery GetProductGalleryById(int galleryid)
        {
            return _context.ProductGalleries.Find(galleryid);
        }

        public List<Product> Get24OfNewProducts()
        {
            return _context.Products.OrderByDescending(p => p.CreateDate).Take(24).ToList();
        }

        public IEnumerable<ProductFeaturesViewModel> GetProductFeaturesByProductIdForShowingPage(int productid)
        {
            List<ProductFeaturesViewModel> List = new List<ProductFeaturesViewModel>();


            var Feature = _context.ProductFeatures.Include(F => F.Feature)
                .Where(F => F.ProductId == productid).ToList();


            foreach (var item in Feature.Where(PF => PF.ProductId == productid).DistinctBy(F => F.FeatureId))
            {
                List.Add(new ProductFeaturesViewModel
                {
                    FeatureTitle = item.Feature.FeatureTitle,
                    Values = _context.ProductFeatures.Where(PF => PF.FeatureId == item.FeatureId && PF.ProductId == productid).Select(PF => PF.Value).ToList()
                });
            }

            return List.ToList();
        }

        public IEnumerable<ProductComments> GetProductCommentsByProductId(int productid)
        {
            return _context.ProductComments.Where(PC => PC.ProductId == productid).ToList();
        }

        public ProductComments GetCommentByCommentId(int commentid)
        {
            return _context.ProductComments.Find(commentid);
        }

        public Tuple<List<ProductComments>, int> GetCommentsForProduct(int productId, int pageId = 1)
        {
            int take = 30;
            int skip = (pageId - 1) * take;

            int commentCount = _context.ProductComments.Where(pc => pc.ProductId == productId).Count() / take;

            if ((commentCount % 2) != 0)
            {
                commentCount += 1;
            }


            return Tuple.Create(_context.ProductComments
                .Where(pc => pc.ProductId == productId)
                .Include(pc => pc.User)
                .Skip(skip).Take(take)
                .OrderByDescending(pc => pc.CreateDate)
                .ToList(), commentCount);
        }

        public DTOs.CompareItemViewModel GetCompareByProductId(int id)
        {
            return _context.Products.Where(p => p.ProductId == id)
                .Select(p => new DTOs.CompareItemViewModel
                {
                    ProductId = id,
                    ImageName = p.ImageName,
                    ProductTitle = p.Title
                }).Single();
        }

        #endregion

        #region Update
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
        #endregion

        #region Delete
        public void DeleteFeature(ProductFeature productFeature)
        {
            _context.ProductFeatures.Remove(productFeature);
            _context.SaveChanges();
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




        #endregion

        #region Filter Product
        public FilterProductViewModel FilterProduct(int PageId = 1, string title = "", int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0)
        {
            if (take is 0)
                take = 24;

            IQueryable<Product> result = _context.Products.Include(c => c.SelectedGroups);


            if (!string.IsNullOrEmpty(title))
                result = result.Where
                (
                c => c.Title.Contains(title) || c.Text.Contains(title) ||
                c.ShortDescription.Contains(title)
                );

            if (startPrice > 0)
                result = result.Where(p => p.Price > startPrice);

            if (endPrice > 0)
                result = result.Where(p => p.Price < endPrice);

            if (selectedGroups.Any())
                foreach (var groupId in selectedGroups)
                {
                    result = _context.SelectedGroups.Where(s => s.GroupId == groupId).Select(s => s.Product);
                }
            result.Distinct();

            int skip = (PageId - 1) * take;
            FilterProductViewModel filterViewModel = new FilterProductViewModel()
            {
                CurrentPage = PageId,
                PageCount = result.Count() / take,
                Products = result.Skip(skip).Take(take).ToList()
            };

            return filterViewModel;
        }
        #endregion

        #region Search

        public List<Product> Search(string q)
        {
            List<Product> result = new List<Product>();

            if (_context.ProductTags.Any(t => t.Tag.Contains(q)))
            {
                result.AddRange(_context.ProductTags
                    .Where(t => t.Tag.Contains(q)).Select(t => t.Product));
            }

            result.AddRange(_context.Products.Where(p => p.ShortDescription.Contains(q) ||
            p.Title.Contains(q) || p.Text.Contains(q)));

            return result.Distinct().ToList();
        }


        #endregion
    }
}