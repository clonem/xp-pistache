using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xp.pistache.core.Domain.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
