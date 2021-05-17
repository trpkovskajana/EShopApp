using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Domain.Domain
{
    public class ProductInOrder : BaseEntity
    {
        // so nasleduvanjeto od BaseEntity kje ima ovaa tabela i svoj kluc plus
        public Guid ProductId { get; set; }
        public Product product { get; set; }
        public Guid OrderId { get; set; }
        public Order order { get; set; }

    }
}
