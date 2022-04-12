using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Address
{
    public interface IAddressQuery
    {
        List<AddressqueryModel> GetAcountAddress(long id);
    }
}
