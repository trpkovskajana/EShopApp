using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class ProductInShoppingCart : BaseEntity
    {
        // so nasleduvanjeto od BaseEntity i ovaa tabela dobiva svoj id 
        public Product product { get; set; }
        public ShoppingCart cart { get; set; }
        public int Qantity { get; set; }
        public Guid ProductId { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
