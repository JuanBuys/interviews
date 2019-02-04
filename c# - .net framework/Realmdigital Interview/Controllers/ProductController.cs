using System.Collections.Generic;
using System.Web.Http;
using Realmdigital_Interview.Services;

namespace Realmdigital_Interview.Controllers
{
    public class ProductController
    {

        [Route("product")]
        public object GetProductById(string productId)
        {
            ProductService ProductService = new ProductService();

            return ProductService.GetProductById(productId);
        }

        [Route("product/search")]
        public List<object> GetProductsByName(string productName)
        {
            ProductService ProductService = new ProductService();

            return ProductService.GetProductsByName(productName);
        }
    }


}