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
    public class OrderService : IOrderService
    {
        private EshopContext _context;

        public OrderService(EshopContext context)
        {
            _context = context;
        }

        public int AddOrder(string UserName, int productId)
        {
            int UserId = _context.Users.Single(u => u.UserName == UserName).UserId;

            var order = _context.Order.SingleOrDefault(o => o.UserId == UserId && !o.IsFainaly);

            var product = _context.Products.Find(productId);

            if (order == null)
            {
                order = new Order()
                {
                    UserId = UserId,
                    OrderSum = product.Price,
                    CreateTime = DateTime.Now,
                    IsFainaly = false,
                    OrderDetail = new List<OrderDetail>()
                    {
                       new OrderDetail()
                       {
                           Count = 1,
                           EndPrice = product.Price,
                           ProductId= product.ProductId,
                           Price = product.Price,
                       }
                    }
                };

                _context.Add(order);
                _context.SaveChanges();
            }
            else
            {
                var orderDetail = _context.OrderDetail
                    .FirstOrDefault(od => od.OrderId == order.OrderId && od.ProductId == product.ProductId);

                if (orderDetail != null)
                {
                    orderDetail.Count += 1;
                    _context.OrderDetail.Update(orderDetail);
                    _context.Order.Update(order);
                    _context.SaveChanges();
                }
                else
                {
                    orderDetail = new OrderDetail()
                    {
                        ProductId = product.ProductId,
                        Count = 1,
                        EndPrice = product.Price,
                        OrderId = order.OrderId,
                        Price = product.Price
                    };
                    _context.OrderDetail.Add(orderDetail);
                    _context.SaveChanges();
                }

                UpdateOrderPrice(order.OrderId);
            }
            return order.OrderId;
        }

        public List<OrderdProductItemViewModel> GetOrdersForUserInBasket(string UserName)
        {
            int userId = _context.Users.Single(u => u.UserName == UserName).UserId;

            var orders = _context.Order.Where(o => !o.IsFainaly && o.UserId == userId).ToList();

            List<OrderdProductItemViewModel> viewModel = new List<OrderdProductItemViewModel>();

            foreach (var order in orders)
            {
                viewModel = _context.OrderDetail.Include(od => od.Product)
                    .Where(od => od.OrderId == order.OrderId)
                    .Select(od => new OrderdProductItemViewModel
                    {
                        ProductId = od.ProductId,
                        Count = od.Count,
                        ImageName = od.Product.ImageName,
                        Title = od.Product.Title
                    }).ToList();
            }

            return viewModel;
        }

        public void UpdateOrderPrice(int orderId)
        {
            var order = _context.Order.Find(orderId);

            order.OrderSum = _context.OrderDetail.Where(od => od.OrderId == orderId)
                .Sum(od => od.Price * od.Count);

            _context.Order.Update(order);
            _context.SaveChanges();
        }
    }
}
