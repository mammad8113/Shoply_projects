using _01_framwork.Applicatin;
using AcountManagement.Application.Contracts.Rol;
using AcountManagement.Domain.Rol.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Rol
{
    public class RolApplication : IRolApplication
    {
        private readonly IRolRepository rolRepository;

        public RolApplication(IRolRepository rolRepository)
        {
            this.rolRepository = rolRepository;
        }

        public OperationResult Create(CreateRol command)
        {
            var operation = new OperationResult();
            if (rolRepository.Exist(x => x.Name == command.Name))
                return operation.Faild(ApplicationMessage.DoblicatedMessage);

            var rol = new Domain.Rol.Agg.Rol(command.Name, new List<Permission>());

            rolRepository.Create(rol);
            rolRepository.Save();
            return operation.Success();
        }

        public OperationResult Edit(EditRol command)
        {
            var operation = new OperationResult();
            var rol = rolRepository.Get(command.Id);
            if (rol == null)
                return operation.Faild(ApplicationMessage.NullMessage);

            if (rolRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Faild(ApplicationMessage.DoblicatedMessage);

            var permissions = new List<Permission>();

            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            rol.Edit(command.Name, permissions);
            rolRepository.Save();
            return operation.Success();
        }

        public List<RolViewModel> GetAll()
        {
            return rolRepository.GetAll();
        }

        public EditRol GetDetals(long id)
        {
            return rolRepository.GetDetals(id);
        }
    }
}
