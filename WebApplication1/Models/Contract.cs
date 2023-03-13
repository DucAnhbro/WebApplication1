using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositPrice { get; set; }
        public decimal RentPrice { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual DetailMotel Room { get; set; } = null!;
    }
}
