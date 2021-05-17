using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class Product : BaseEntity
    {
        //public Guid Id { get; set; }
        [Required]
        public String ProductName { get; set; }
        [Required]
        public String ProductImage { get; set; }
        [Required]
        public String ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<ProductInShoppingCart> products { get; set; }
        public virtual ICollection<ProductInOrder> productsInOrders { get; set; }
    }
}
