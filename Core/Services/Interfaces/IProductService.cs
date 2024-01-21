using Core.DTOs;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IProductService
    {

        #region Add 
        void AddProductTags(int productid, string tag);
        void AddProductSelectedGroups(int productid, List<int> groupid);
        void AddProduct(Product product, List<int> groups, string tags, IFormFile imagename);
        void AddProductFeature(ProductFeature productFeature);
        void AddProductGallery(ProductGallery productgallery, IFormFile imagename);
        void AddProductComment(ProductComments comment, string userName);
        #endregion


        #region Get
        IEnumerable<Product> GetAll();
        IEnumerable<ProductGroup> GetAllProductGroups(int productid);
        Product GetProductById(int productid);
        string GetTagsForShowingInEditProductOnAdmin(int productid);
        List<Feature> GetAllFeatures();
        List<ProductFeature> GetProductFeaturesByProductIdForAdmin(int productid);
        ProductFeature GetProductFeatureByid(int productfeatureid);
        List<ProductGallery> GetProductGalleriesByProductId(int productid);
        ProductGallery GetProductGalleryById(int galleryid);
        List<Product> Get24OfNewProducts();
        IEnumerable<ProductFeaturesViewModel> GetProductFeaturesByProductIdForShowingPage(int productid);
        IEnumerable<ProductComments> GetProductCommentsByProductId(int productid);
        ProductComments GetCommentByCommentId(int commentid);
        Tuple<List<ProductComments>, int> GetCommentsForProduct(int productId, int pageId = 1);
        DTOs.CompareItemViewModel GetCompareByProductId(int id); 

        #endregion

        #region Update
        void UpdateProduct(Product product, List<int> groups, string tags, IFormFile imagename);
        void UpdateProductTags(int productid, string tag);
        void UpdateProductSelectedGroups(int productid, List<int> groupid);
        #endregion


        #region Delete
        void DeleteFeature(ProductFeature productFeature);
        void DeleteProductGallery(int galleryid);
        #endregion

        #region Filter Product
        FilterProductViewModel FilterProduct(int PageId = 1, string title = "",
            int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0);
        #endregion

        #region Search

        List<Product> Search(string q);

        #endregion
    }
}
