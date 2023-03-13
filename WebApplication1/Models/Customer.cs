using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
            Motels = new HashSet<Motel>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int Age { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int? Phone { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Motel> Motels { get; set; }
    }
}
