using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace xp.pistache.core.Domain.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public string? Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
