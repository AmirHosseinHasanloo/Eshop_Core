using Core.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string UserName, int productId);
        List<OrderdProductItemViewModel> GetOrdersForUserInBasket(string UserName);
        void UpdateOrderPrice(int orderId);
    }
}
