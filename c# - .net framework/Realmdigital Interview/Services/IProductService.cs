using Realmdigital_Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realmdigital_Interview.Services
{
    interface IProductService
    {
        object GetProductById(string ProductID);
        List<object> GetProductsByName(string productName);
    }
}
