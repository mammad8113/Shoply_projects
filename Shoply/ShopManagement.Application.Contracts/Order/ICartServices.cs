using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public interface ICartServices
    {
        Cart Get();
        void Set(Cart cart);
    }
}
