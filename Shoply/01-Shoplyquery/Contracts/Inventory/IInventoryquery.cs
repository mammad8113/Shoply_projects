using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Inventory
{
    public interface IInventoryquery
    {
        InStock CheckInstock(StatuseInevntory statuseInevntory);
    }
}
