using EShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class ShoppingCart : BaseEntity
    {
        //public Guid Id { get; set; }
        public String OwnerId { get; set; } //nadvoresen kluc za so korisnikot (user)
        public EShopApplicationUser owner { get; set; }
        public virtual ICollection<ProductInShoppingCart> products { get; set; }
    }
}
