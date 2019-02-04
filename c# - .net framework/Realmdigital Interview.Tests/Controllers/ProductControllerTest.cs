using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Services;
using System.Collections.Generic;

namespace Realmdigital_Interview.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void GetProductsByName()
        {
            ProductService Service = new ProductService();
            var result = Service.GetProductsByName("Pump");
            
            Assert.AreSame(typeof(List<object>), result);
        }

        [TestMethod]
        public void GetProductById()
        {
            ProductService Service = new ProductService();
            var result = Service.GetProductById("100");

            Assert.AreSame(typeof(object), result);
        }

    }
}
