namespace ShopManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public bool IsCanceld { get;  set; }
        public bool IsConfirm { get;  set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public string CreationDate { get; set; }
    }
}
