using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Infrastructure
{
    public class NeddsPermissionAttribute : Attribute
    {
        public int Permission { get; set; }

        public NeddsPermissionAttribute(int permission)
        {
          Permission = permission;
        }
    }
}
