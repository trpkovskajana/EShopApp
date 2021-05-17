using EShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Order : BaseEntity
    {
        //public Guid Id { get; set; } ova go zamenivme so nasleduvanjeto od BaseEntity
        public String userId { get; set; }
        public EShopApplicationUser user { get; set; }

        // bidejki order so produkti ima many-many relacija 
        public virtual ICollection<ProductInOrder> products { get; set; }

    }
}
