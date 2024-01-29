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
        List<OrderdProductItemViewModel> GetOrdersForUserInBasket(string userName);
        void UpdateOrderPrice(int orderId);
        void UpdateOrderDetailPrice(int orderDetailId, int count, string userName);
        void DeleteOrderDetail(int orderDetailId,string userName);
        List<OrderDetail> GetOrdersForUserInPayment(string userName);
    }
}
