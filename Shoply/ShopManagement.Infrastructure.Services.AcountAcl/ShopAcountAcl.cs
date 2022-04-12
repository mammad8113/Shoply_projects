using AcountManagement.Application.Contracts.Acount;
using ShopManagement.Domain.Services;
using System;

namespace ShopManagement.Infrastructure.Services.AcountAcl
{
    public class ShopAcountAcl : IShopAcountAcl
    {
        private readonly IAcountApplication acountApplication;

        public ShopAcountAcl(IAcountApplication acountApplication)
        {
            this.acountApplication = acountApplication;
        }

        public (string name, string mobil) GetAcountBy(long id)
        {
            var acount=acountApplication.GetAcount(id);
            return (acount.Fullname, acount.Mobile);
        }
    }
}
