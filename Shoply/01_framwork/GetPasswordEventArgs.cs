using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork
{
    public class GetPasswordEventArgs : EventArgs
    {
        public string Mobile { get; set; }
        public string Code { get; set; }
    }
}
