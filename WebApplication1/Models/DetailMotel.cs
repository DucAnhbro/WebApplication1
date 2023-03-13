using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DetailMotel
    {
        public DetailMotel()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public int MotelId { get; set; }
        public string RoomNumber { get; set; } = null!;
        public decimal AreaOfRoom { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        public virtual Motel Motel { get; set; } = null!;
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
