﻿using DataLayer.Entities;
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
}