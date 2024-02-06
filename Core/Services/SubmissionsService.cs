using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private EshopContext _context;

        public SubmissionsService(EshopContext context)
        {
            _context = context;
        }

        public void ChangeOrderIsSendByForm(int orderId, bool isSend)
        {
            var Order = _context.Order.Find(orderId);
            Order.IsSend = isSend;
            _context.Update(Order);
            _context.SaveChanges();
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return _context.OrderDetail.Where(od => od.OrderId == orderId)
                .Include(od => od.Product).ToList();
        }

        public List<SubmissionsProductsViewModel> GetUnSendedSubmissions()
        {
            var orders = _context.Order
                .Where(o => !o.IsSend && o.IsFainaly).Include(o => o.User)
                .Select(o=>new SubmissionsProductsViewModel
                {
                    Customer = o.User.UserName,
                    location = o.User.location,
                    IsSend = o.IsSend,
                    OrderId = o.OrderId,
                    OrderSum = o.OrderSum,
                });

            return orders.ToList();
        }
    }
}
