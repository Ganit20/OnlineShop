using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OnlineShop.Model
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }

        [InverseProperty(nameof(User.UserRole))]
        public virtual ICollection<User> Users { get; set; }
    }
}
