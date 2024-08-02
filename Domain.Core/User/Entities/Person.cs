using Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Email { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Role Role { get; set; }
    }
}
