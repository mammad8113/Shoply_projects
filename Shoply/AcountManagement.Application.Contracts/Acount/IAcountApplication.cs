using _01_framwork;
using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Acount
{
    public abstract class IAcountApplication
    {
        public delegate void GetPasswordEventHandler(object sender, GetPasswordEventArgs e);

        public virtual event GetPasswordEventHandler getPassword;
        public void OnGetPassword(GetPasswordEventArgs args)
        {
            getPassword?.Invoke(this, args);
        }

        public abstract OperationResult Create(RegisterAcount command);
        public abstract OperationResult Edit(EditAcount command);
        public abstract OperationResult ChangPassword(ChangPassword command);
        public abstract PasswordResult GetPassword(RegesterMobil command);
        public abstract OperationResult Login(Login command);
        public abstract EditAcount GetDetals(long id);
        public abstract AcountViewModel GetAcount(long id);
        public abstract List<AcountViewModel> Search(AcountSearchModel searchModel);
        public abstract List<AcountViewModel> GetAll();
        public abstract void Logout();
        public abstract int NewAcount();
        public abstract string GetPhoto(long id);
    }
}
