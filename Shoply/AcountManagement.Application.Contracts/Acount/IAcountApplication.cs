using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Acount
{
    public interface IAcountApplication
    {
        OperationResult Create(RegisterAcount command);
        OperationResult Edit(EditAcount command);
        OperationResult ChangPassword(ChangPassword command);
        PasswordResult GetPassword(RegesterMobil command);
        OperationResult Login(Login command);
        EditAcount GetDetals(long id);
        AcountViewModel GetAcount(long id);
        List<AcountViewModel> Search(AcountSearchModel searchModel);
        public List<AcountViewModel> GetAll();
        void Logout();
        int NewAcount();
        public string GetPhoto(long id);
    }
}
