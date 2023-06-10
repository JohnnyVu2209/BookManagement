using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Server.DL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity))
                return false;

            return Id == ((BaseEntity)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
