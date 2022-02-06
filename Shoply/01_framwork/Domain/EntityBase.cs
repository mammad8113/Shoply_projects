using System;

namespace _01_framwork
{
    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
