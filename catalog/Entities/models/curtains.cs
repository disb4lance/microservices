using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.models
{
    public class curtains
    {
        public Guid id { get; set; }

        public  string name { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public string matherial { get; set; }

        public string color { get; set; }

        public double height { get; set; }

        public double width { get; set; }

        public string ImageUrl { get; set; }
    }
}
