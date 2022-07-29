using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Core.Domain
{
    public class User
    {
        public string Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public DateTime CreationTime { get; set; } = default!;
        public bool IsActive { get; set; } = default!;
        public bool IsAdmin { get; set; } = default!;
    }
}
