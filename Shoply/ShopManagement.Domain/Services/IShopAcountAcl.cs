using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Services
{
    public interface IShopAcountAcl
    {
        (string name,string mobil) GetAcountBy(long id);
    }
}
