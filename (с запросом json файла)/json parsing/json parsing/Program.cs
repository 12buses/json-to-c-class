using json_parsing.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace json_parsing
{
    public class products
    {
        public int productId;
        public string category;
    }



    internal class Program
    {
        private List<products> items;

        void Start()
        {
            using (StreamReader r = new StreamReader("json.txt"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<products>>(json);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program(); 
            program.Start();

            foreach (products cur in program.items)
            {
                Console.WriteLine(cur.productId + " " + cur.category);
            }
        }
    }
}