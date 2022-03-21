using _01_framwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Rol
{
    public class CreateRol
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }
}
