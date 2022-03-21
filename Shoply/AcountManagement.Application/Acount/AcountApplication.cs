﻿using _01_framwork.Applicatin;
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
        public AcountApplication(IAcountRepository acountRepository, IPasswordHasher passwordHasher, IFileUploader fileUploader, IAuthHelper authHelper,
            IRolRepository rolRepository)
        {
            this.acountRepository = acountRepository;
            this.passwordHasher = passwordHasher;
            this.fileUploader = fileUploader;
            this.authHelper = authHelper;
            this.rolRepository = rolRepository;
        }

        public OperationResult ChangPassword(ChangPassword command)
        {
            var operation = new OperationResult();
            var Acount = acountRepository.Get(command.Id);
            if (Acount == null)
                return operation.Faild(ApplicationMessage.NullMessage);

            if (command.Password != command.RePassword)
                return operation.Faild(ApplicationMessage.PasswordNotMath);

            var password = passwordHasher.Hash(command.Password);
            Acount.ChangPassword(password);
            acountRepository.Save();
            return operation.Success();
        }
        public OperationResult Create(RegisterAcount command)
        {
            var operation = new OperationResult();
            if (acountRepository.Exist(x => x.Username == command.Username))
                return operation.Faild(ApplicationMessage.ExistUsername);

            if (acountRepository.Exist(x => x.Mobile == command.Mobile))
                return operation.Faild(ApplicationMessage.ExistMobil);

            if (command.RolId == 0)
            {
                if (command.Password != command.RePassword)
                    return operation.Faild(ApplicationMessage.PasswordNotMath);
            }

            var path = $"Acounts";
            var picture = fileUploader.Upload(command.UserPhoto, path);

            var password = passwordHasher.Hash(command.Password);

            var acount = new Domain.Acount.Agg.Acount(command.Fullname, command.Username, command.Mobile, password,
                command.RolId, picture);

            acountRepository.Create(acount);
            acountRepository.Save();

            if (command.RolId == 0)
            {
                var permissions = rolRepository.Get(acount.RolId).Permissions.Select(x => x.Code).ToList();

                var Auth = new AuthViewModel(acount.Id, acount.Fullname, acount.Username, acount.RolId, acount.Password, acount.Mobile,permissions);
                authHelper.Signin(Auth);
            }

            return operation.Success();
        }

        public OperationResult Edit(EditAcount command)
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

            acountRepository.Save();
            return operation.Success();
        }

        public AcountViewModel GetAcount(long id)
        {
            return acountRepository.GetAcount(id);
        }

        public List<AcountViewModel> GetAll()
        {
            return acountRepository.GetAcounts();
        }

        public EditAcount GetDetals(long id)
        {
            return acountRepository.GetDetals(id);
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var acount = acountRepository.GetBy(x => x.Username == command.UserName);
            if (acount == null)
                return operation.Faild(ApplicationMessage.NotFoundUser);

            var (Verified, NeedsUpgrade) = passwordHasher.Check(acount.Password, command.Password);

            if (!Verified)
                return operation.Faild(ApplicationMessage.NotFoundUser);

            var permissions = rolRepository.Get(acount.RolId).Permissions.Select(x => x.Code).ToList();

            var Auth = new AuthViewModel(acount.Id, acount.Fullname, acount.Username, acount.RolId, acount.Password, acount.Mobile, permissions);

            authHelper.Signin(Auth);
            return operation.Success();

        }

        public void Logout()
        {
            authHelper.SignOut();
        }

        public List<AcountViewModel> Search(AcountSearchModel searchModel)
        {
            return acountRepository.Search(searchModel);
        }
    }
}