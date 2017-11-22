using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2Minds.Models;

namespace WebApplication2Minds.Utilities
{
    public class DataMock
    {
        public static IEnumerable<Product> MockProducts(int count)
        {
            var random = new Random();
            var codes = Enumerable.Range(1, 99999).OrderBy(c => random.Next()).Take(count).ToList();
            var names = Enumerable.Range(1, count).Select(i => Utilities.Extensions.RandomString(random.Next(5, 15))).ToList();
            var prices = Enumerable.Range(1, count).Select(i => random.Next(10, 5000).RoundOff()).ToList();
            var barcodes = Enumerable.Range(1, count).Select(i => Utilities.Extensions.RandomString(13)).ToList();

            return Enumerable.Range(0, count).Select(i => new Product() { Code = codes[i], Name = names[i], Price = prices[i], Barcode = barcodes[i] });
        }
    }
}