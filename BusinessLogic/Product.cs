using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Product
    {
        public string Name { get; }

        public Product(string name, decimal price)
        {
            Name = name;
        }
    }
}
