using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Realmdigital_Interview.Services;

namespace Realmdigital_Interview.Tests.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void ProcessAPIResult()
        {
            ProductService ProductService = new ProductService();

            var Response = "[{ \"BarCode\":\"bar_code_1\",\"ItemName\":\"item_name_1\",\"PriceRecords\":[{\"SellingPrice\":100,\"CurrencyCode\":\"USD\"},{\"SellingPrice\":1000,\"CurrencyCode\":\"ZAR\"},{\"SellingPrice\":90,\"CurrencyCode\":\"EUR\"}]},{ \"BarCode\":\"bar_code_2\",\"ItemName\":\"item_name_2\",\"PriceRecords\":[{\"SellingPrice\":290,\"CurrencyCode\":\"USD\"},{\"SellingPrice\":1500,\"CurrencyCode\":\"ZAR\"},{\"SellingPrice\":90,\"CurrencyCode\":\"EUR\"}]}]";

            var result =  ProductService.ProcessAPIResult(Response);

            Assert.IsNotNull(result);
            Assert.AreSame(typeof(List<object>), result);

        }

        [TestMethod]
        public void GetProductById()
        {
            ProductService Service = new ProductService();
            var result = Service.GetProductById("100");

            Assert.AreSame(typeof(object), result);
        }

        [TestMethod]
        public void GetProductsByName()
        {
            ProductService Service = new ProductService();
            var result = Service.GetProductsByName("Pump");

            Assert.AreSame(typeof(List<object>), result);

        }        

        
    }
}
