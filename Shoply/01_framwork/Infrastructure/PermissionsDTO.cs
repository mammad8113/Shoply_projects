namespace _01_framwork.Infrastructure
{
    public class PermissionsDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PermissionsDTO(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
