using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class States
    {
        public long Id { get; set; }
        public string Name { get; set; }

        private States(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<States> GetAll()
        {
            return new List<States>()
            {
                new States((int)StateId.alborz,"البرز"),
                new States((int)StateId.tehran,"تهران"),
                new States((int)StateId.ghazvin,"قزوین"),
                new States((int)StateId.hamedan,"همدان"),
            };
        }

        public static States getBy(long id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
