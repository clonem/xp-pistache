using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace xp.pistache.core.Domain.DTOs.Portfolio
{
    public class RequestSellProductDTO
    {
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
