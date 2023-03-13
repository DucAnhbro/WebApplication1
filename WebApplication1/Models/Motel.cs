using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Motel
    {
        public Motel()
        {
            DetailMotels = new HashSet<DetailMotel>();
        }

        public int Id { get; set; }
        public string MotelName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int TotalRoom { get; set; }
        public int HostPhone { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<DetailMotel> DetailMotels { get; set; }
    }
}
