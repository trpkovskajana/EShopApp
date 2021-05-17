using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DTO
{
    public class ShoppingCartDto
    {
        // listava e od ovoj tip bidejki vo taa klasa ni se naogja quantity
        public List<ProductInShoppingCart> productInShoppingCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
