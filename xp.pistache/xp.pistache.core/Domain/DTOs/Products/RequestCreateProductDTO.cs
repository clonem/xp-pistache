using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace xp.pistache.core.Domain.DTOs.Products
{
    public class RequestCreateProductDTO
    {
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public required string Status { get; set; }
    }
}
