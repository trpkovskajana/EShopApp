﻿using EShop.Domain.Domain;
using EShop.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Order> getAllActiveOrders()
        {
            return this._orderService.getAllOrders();
        }
    }
}
