using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Services.Interface
{
    public interface IOrderService
    {
        List<Order> getAllOrders();
    }
}
