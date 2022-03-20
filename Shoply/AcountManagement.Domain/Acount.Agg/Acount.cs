using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Domain.Acount.Agg
{
    public class Acount : EntityBase<long>
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public string UserPhoto { get; private set; }
        public long RolId { get; private set; }
        public Rol.Agg.Rol Rol { get; private set; }

        protected Acount()
        {

        }
        public Acount(string fullname, string user, string mobile, string password, long rolId, string userPhoto)
        {
            Fullname = fullname;
            Username = user;
            Mobile = mobile;
            Password = password;
            RolId = rolId;
            if (rolId == 0)
                RolId = 2;

            UserPhoto = userPhoto;
        }

        public void Edit(string fullname, string user, string mobile, long rolId, string userPhoto)
        {
            Fullname = fullname;
            Username = user;
            Mobile = mobile;
            RolId = rolId;
            if (!string.IsNullOrWhiteSpace(userPhoto))
                UserPhoto = userPhoto;
        }

        public void ChangPassword(string password)
        {
            Password = password;
        }
    }
}
