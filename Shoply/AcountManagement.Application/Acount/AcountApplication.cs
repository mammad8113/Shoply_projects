using _0_Framework.Application;
using _01_framwork;
using _01_framwork.Applicatin;
using _01_framwork.Applicatin.Sms;
using _01_framwork.Infrastructure;
using AcountManagement.Application.Contracts.Acount;
using AcountManagement.Domain.Acount.Agg;
using AcountManagement.Domain.Rol.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Acount
{
  
    public class AcountApplication : IAcountApplication
    {
        private readonly IAcountRepository acountRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IFileUploader fileUploader;
        private readonly IAuthHelper authHelper;
        private readonly IRolRepository rolRepository;
        private readonly ISmsService smsService;
        public AcountApplication(IAcountRepository acountRepository, IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper,
            IRolRepository rolRepository, ISmsService smsService)
        {
            this.acountRepository = acountRepository;
            this.passwordHasher = passwordHasher;
            this.fileUploader = fileUploader;
            this.authHelper = authHelper;
            this.rolRepository = rolRepository;
            this.smsService = smsService;
        }

       

       

        public override OperationResult ChangPassword(ChangPassword command)
        {
            var operation = new OperationResult();
            var Acount = acountRepository.Get(command.Id);
            if (Acount == null)
                return operation.Faild(ApplicationMessage.NullMessage);

            if (command.Password != command.RePassword)
                return operation.Faild(ApplicationMessage.PasswordNotMath);

            var password = passwordHasher.Hash(command.Password);
            Acount.ChangPassword(password);
            try
            {
                acountRepository.Save();
            }
            catch
            {
                return operation.Faild(ApplicationMessage.UnspecifiedError);
            }
            return operation.Success();
        }
        public override OperationResult Create(RegisterAcount command)
        {
            var operation = new OperationResult();
            if (acountRepository.Exist(x => x.Username == command.Username))
                return operation.Faild(ApplicationMessage.ExistUsername);

            if (acountRepository.Exist(x => x.Mobile == command.Mobile))
                return operation.Faild(ApplicationMessage.ExistMobil);

            if (command.RolId == 0)
            {
                command.RolId = int.Parse(Rols.SystemUser);

                if (command.Password != command.RePassword)
                    return operation.Faild(ApplicationMessage.PasswordNotMath);
            }

            var path = $"Acounts";
            var picture = fileUploader.Upload(command.UserPhoto, path);

            var password = passwordHasher.Hash(command.Password);

            var acount = new Domain.Acount.Agg.Acount(command.Fullname, command.Username, command.Mobile, password,
                command.RolId, picture);

            acountRepository.Create(acount);
            try
            {
                acountRepository.Save();
            }
            catch
            {
                return operation.Faild(ApplicationMessage.NullFildMessage);
            }

            var permissions = rolRepository.Get(acount.RolId).Permissions.Select(x => x.Code).ToList();

            var Auth = new AuthViewModel(acount.Id, acount.Fullname, acount.Username, acount.RolId, acount.Password, acount.Mobile, DateTime.Now.ToFarsi(), permissions);
            authHelper.Signin(Auth);

            return operation.Success();
        }

        public override OperationResult Edit(EditAcount command)
        {
            var operation = new OperationResult();

            var acount = acountRepository.Get(command.Id);
            if (acount == null)
                return operation.Faild(ApplicationMessage.NullMessage);

            if (acountRepository.Exist(x => x.Username == command.Username && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.ExistUsername);

            if (acountRepository.Exist(x => x.Mobile == command.Mobile && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.ExistMobil);


            var path = $"Acount";
            var picture = fileUploader.Upload(command.UserPhoto, path);

            acount.Edit(command.Fullname, command.Username, command.Mobile,
                command.RolId, picture);
            try
            {
                acountRepository.Save();
            }
            catch
            {
                return operation.Faild(ApplicationMessage.NullFildMessage);
            }
            return operation.Success();
        }

        public override AcountViewModel GetAcount(long id)
        {
            return acountRepository.GetAcount(id);
        }

        public override List<AcountViewModel> GetAll()
        {
            return acountRepository.GetAcounts();
        }

        public override EditAcount GetDetals(long id)
        {
            return acountRepository.GetDetals(id);
        }

        public override PasswordResult GetPassword(RegesterMobil command)
        {
            var operation = new PasswordResult();
            var acount = acountRepository.GetBy(x => x.Mobile == command.Mobile);
            if (acount != null)
            {
                if (acount.Mobile != command.Mobile)
                    return operation.Faild("همچین شماره ای در سیستم موجود نیست");

                var random = new Random();
                int num1 = random.Next(0, 9);
                int num2 = random.Next(0, 9);
                int num3 = random.Next(0, 9);
                int num4 = random.Next(0, 9);
                var code = $"{num1}{num2}{num3}{num4}";
                OnGetPassword(new GetPasswordEventArgs()
                {
                    Code = code,
                    Mobile = command.Mobile
                });
                return operation.Successs("عملیات با موفقعیت انجام شد", code, acount.Id);
            }
            return operation.Faild("همچین شماره ای در سیستم موجود نیست");

        }

        public override string GetPhoto(long id)
        {

            return acountRepository.GetPhoto(id);
        }

        public override OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var acount = acountRepository.GetBy(x => x.Username == command.UserName);
            if (acount == null)
                return operation.Faild(ApplicationMessage.NotFoundUser);

            var (Verified, NeedsUpgrade) = passwordHasher.Check(acount.Password, command.Password);

            if (!Verified)
                return operation.Faild(ApplicationMessage.NotFoundUser);

            var permissions = rolRepository.Get(acount.RolId).Permissions.Select(x => x.Code).ToList();

            var Auth = new AuthViewModel(acount.Id, acount.Fullname, acount.Username, acount.RolId, acount.Password, acount.Mobile, DateTime.Now.ToFarsi(), permissions);

            authHelper.Signin(Auth);
            return operation.Success();

        }

        public override void Logout()
        {
            authHelper.SignOut();
        }

        public override int NewAcount()
        {
            return acountRepository.NewAcount();
        }

        public  override List<AcountViewModel> Search(AcountSearchModel searchModel)
        {
            return acountRepository.Search(searchModel);
        }
    }
}
