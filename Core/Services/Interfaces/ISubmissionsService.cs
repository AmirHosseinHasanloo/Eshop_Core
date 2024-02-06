using Core.DTOs;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ISubmissionsService
    {
        List<SubmissionsProductsViewModel> GetUnSendedSubmissions();
        List<OrderDetail> GetOrderDetailByOrderId(int orderId);
        void ChangeOrderIsSendByForm(int orderId,bool isSend);
    }
}
