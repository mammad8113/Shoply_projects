using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Comment.Agg
{
    public class Comment : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Message { get; private set; }
        public string Email { get; private set; }
        public bool IsCanceld { get; private set; }
        public bool IsConfirm { get; private set; }
        public long ProductId { get; private set; }
        public Product.Agg.Product Product { get; private set; }

        public Comment(string name, string message, string email, long productId)
        {
            Name = name;
            Message = message;
            Email = email;
            ProductId = productId;
        }
        public void Confirm()
        {
            IsConfirm = true;
            IsCanceld = false;
        }
        public void Canceld()
        {
            IsCanceld = true;
            IsConfirm = false;
        }
    }
}
