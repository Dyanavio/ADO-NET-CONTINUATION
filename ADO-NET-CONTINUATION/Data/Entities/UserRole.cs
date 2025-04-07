using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_CONTINUATION.Data.Entities
{
    public class UserRole
    {
        public string Id { get; set; } = null!; // "Admin", "User" etc.
        public string Description { get; set; } = null!;
        public bool CanCreate { get; set; }   //C
        public bool CanRead { get; set; }     //R
        public bool CanUpdate { get; set; }   //U
        public bool CanDelete { get; set; }   //D

    }
}
