using System.Collections.Generic;
using Realmdigital_Interview.Models;
using System.Net;
using Newtonsoft.Json;

namespace Realmdigital_Interview.Services
{

    public class ProductService : IProductService
    {
        public object GetProductById(string productID)
        {
            string response = CallAPI("http://192.168.0.241/eanlist?type=Web", "POST", "{ \"id\": \"" + productID + "\" }");
            
            var result = ProcessAPIResult(response);
            
            return result.Count > 0 ? result[0] : null;
        }

        public List<object> GetProductsByName(string productName)
        {
            string response = CallAPI("http://192.168.0.241/eanlist?type=Web", "POST", "{ \"names\": \"" + productName + "\" }");
           
            var result = ProcessAPIResult(response);

            return result;
        }

        public List<object> ProcessAPIResult(string response)
        {
            var reponseObject = JsonConvert.DeserializeObject<List<ApiResponseProduct>>(response);

            var result = new List<object>();

            for (int i = 0; i < reponseObject.Count; i++)
            {
                var prices = new List<object>();
                for (int j = 0; j < reponseObject[i].PriceRecords.Count; j++)
                {
                    if (reponseObject[i].PriceRecords[j].CurrencyCode == "ZAR")
                    {
                        prices.Add(new
                        {
                            Price = reponseObject[i].PriceRecords[j].SellingPrice,
                            Currency = reponseObject[i].PriceRecords[j].CurrencyCode
                        });
                    }
                }
                result.Add(new
                {
                    Id = reponseObject[i].BarCode,
                    Name = reponseObject[i].ItemName,
                    Prices = prices
                });
            }

            return result;
        }

        private string CallAPI(string url, string callType, string parameter)
        {
            string response = "";

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                response = client.UploadString(url, callType, parameter);
            }

            return response;
        }
    }
}