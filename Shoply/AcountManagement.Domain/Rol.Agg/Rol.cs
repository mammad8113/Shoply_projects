using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Domain.Rol.Agg
{
    public class Role : EntityBase<long>
    {
        public string Name { get; private set; }
        public List<Acount.Agg.Acount> Acounts { get; private set; }
        public List<Permission> Permissions { get; private set; }
        protected Role()
        {

        }
        public Role(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
        public void Edit(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions; 
        }
    }

}
