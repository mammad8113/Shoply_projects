namespace AcountManagement.Application.Contracts.Acount
{
    public class AcountViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public long RolId { get; set; }
        public string Rol { get; set; }
        public string UserPhoto { get; set; }
        public string CreationDate { get; set; }
    }
}
