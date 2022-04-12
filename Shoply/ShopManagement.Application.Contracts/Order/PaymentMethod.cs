using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class PaymentMethod
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get;private set; }

        private PaymentMethod(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>()
            {
                new PaymentMethod((int)PaymentMethodId.online,"پرداخت انلاین ","پرداخت به صورت انلاین صورت میگیرد."),
                new PaymentMethod((int)PaymentMethodId.Cash,"پرداخت درب منزل ",".پرداخت در درب منزل وموقع تحویل بار صورت میگیرد"),
            };
        }


        public static PaymentMethod GetBy(long id)
        {
            return GetList().FirstOrDefault(x=>x.Id == id);    
        } 
    }
}
