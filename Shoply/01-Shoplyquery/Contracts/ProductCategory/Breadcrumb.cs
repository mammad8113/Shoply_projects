using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.ProductCategory
{
    public class Breadcrumb
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public Breadcrumb(string name, long id,string slug)
        {
            Name = name;
            Id = id;
            Slug = slug;
        }
    }
}
