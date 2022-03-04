using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery
{
    public class CustomPage
    {
        public int CurrentPage { get; set; }
        public float Count { get; set; }
        public int number { get; set; } 
        public int Next { get; set; }
        public int Back { get; set; }
        public string Page { get; set; }

        public CustomPage(int currentPage,float count, int number, string page)
        {
            CurrentPage = currentPage;
            this.number = number;
            Count = count;
            Page = page;
            Next = CurrentPage + 1;
            Back = CurrentPage - 1;

        }
    }
}
