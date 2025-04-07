using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_CONTINUATION.Data.Entities
{
    public class UserAccess
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Login { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public string Dk { get; set; } = null!; // Derived key (by RFC 2898)
        public string RoleId { get; set; } = null!;
        public User User { get; set; } = null!; // Navigation property - is a reference to another entity

    }
}
