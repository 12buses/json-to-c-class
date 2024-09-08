using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_parsing.models
{
    internal class Currency
    {
        public class Rootobject
        {
            public string aff_sub1 { get; set; }
            public string aff_sub2 { get; set; }
            public Product[] products { get; set; }
        }

        public class Product
        {
            public int productId { get; set; }
            public string category { get; set; }
        }

    }
}
