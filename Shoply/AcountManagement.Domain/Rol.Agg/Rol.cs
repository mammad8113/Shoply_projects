using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Domain.Rol.Agg
{
    public class Rol : EntityBase<long>
    {
        public string Name { get; set; }
        public List<Acount.Agg.Acount> Acounts { get; set; }

        public Rol(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }

}
