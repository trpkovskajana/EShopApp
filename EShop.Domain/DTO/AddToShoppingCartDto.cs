using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        //sakame da go koristime za od akcijata da se transferiraat podatocite do viewto
        //koj e selektiraniot produkt

        public Product selectedProduct { get; set; }
        public Guid selectedProductId { get; set; }
        public int quantity { get; set; }

    }
}
