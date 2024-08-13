﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace xp.pistache.core.Domain.DTOs.Portfolio
{
    public class ResponseGetClientProductsDTO
    {
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
