namespace _01_framwork.Applicatin
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public long RolId { get; set; }
        public long Role { get; set; }
        public string Mobil { get; set; }
        public string Password { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, string fullname, string username, long rolId, string password,string mobil)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            RolId = rolId;
            Password = password;
            Mobil = mobil;
        }
    }
}