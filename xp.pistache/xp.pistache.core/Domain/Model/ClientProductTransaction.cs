using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xp.pistache.core.Domain.Model
{
    public class ClientProductTransaction
    {
        public int ClientProductID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
