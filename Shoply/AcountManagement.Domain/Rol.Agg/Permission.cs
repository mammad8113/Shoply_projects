namespace AcountManagement.Domain.Rol.Agg
{
    public class Permission
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public long RolId { get; set; }
        public Rol Rol { get; set; }

        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public Permission(int code)
        {
            Code = code;
        }

    }

}
