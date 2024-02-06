using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class SubmissionsProductsViewModel
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public int OrderSum { get; set; }
        public string location { get; set; }
        public bool IsSend { get; set; }
    }
}
