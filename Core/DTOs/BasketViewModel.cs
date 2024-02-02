using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{

    public class OrderdProductItemViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
    }

    public class CompleteUserIdentityViewModel
    {
        public int UserId { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalityCode { get; set; }
        public string PostCode { get; set; }
    }
}
