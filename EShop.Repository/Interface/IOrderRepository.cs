﻿using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> getAllOrders();
        Order getOrderDetails(BaseEntity model);

    }
}
