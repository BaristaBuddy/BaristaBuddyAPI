﻿
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IOrdersRepository
    {
        Task<OrderDTO> GetOneOrder(int id);
        Task<bool> UpdateOrder(int id,Orders order);
        Task<OrderDTO> SaveNewOrder(Orders order);
    }
}
