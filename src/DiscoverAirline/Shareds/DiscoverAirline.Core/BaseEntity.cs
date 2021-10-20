using System;

namespace DiscoverAirline.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public void PrepareToAdd()
        {
            CreatedDate = DateTime.Now;
            Active = true;
        }

        public void PrepareToUpdate()
        {
            UpdateDate = DateTime.Now;
            Active = true;
        }

        public void PrepareToDelete()
        {
            UpdateDate = DateTime.Now;
            Active = false;
        }
    }
}
