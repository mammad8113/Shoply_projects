using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cities
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StatId { get; set; }

        public Cities(long id, string name, long stateId)
        {
            Id = id;
            Name = name;
            StatId = stateId;
        }

        public static List<Cities> GetAll()
        {
            return new List<Cities>()
            {
               new Cities((int)CityId.karaj,"کرج",(int)StateId.alborz),
               new Cities((int)CityId.kamalabad,"کمال اباد",(int)StateId.alborz),
               new Cities((int)CityId.eshtehard,"اشتهارد",(int)StateId.alborz),
               new Cities((int)CityId.nazarAbad,"نظر اباد",(int)StateId.alborz),
               new Cities((int)CityId.tehran,"تهران",(int)StateId.tehran),
               new Cities((int)CityId.tehransar,"تهرانسر",(int)StateId.tehran),
               new Cities((int)CityId.ghazvine,"قزوین",(int)StateId.ghazvin),
               new Cities((int)CityId.takestan,"تاکستان",(int)StateId.ghazvin),
               new Cities((int)CityId.hamedan,"همدان",(int)StateId.hamedan),
               new Cities((int)CityId.bahar,"بهار",(int)StateId.hamedan),
               new Cities((int)CityId.kabodarahang,"کبودراهنگ",(int)StateId.hamedan),
            };
        }

        public static List<Cities> GetcitiesBy(long stateId)
        {
            return GetAll().Where(x=>x.StatId==stateId).OrderByDescending(x=>x.Id).ToList();
        }

        public static Cities  GetBy(long id)
        {
            return GetAll().FirstOrDefault(x=>x.Id==id);
        }

    }
}
