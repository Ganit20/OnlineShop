using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OnlineShop.Model
{
    public partial class User
    {
        public User()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public int UserRoleId { get; set; }

        [ForeignKey(nameof(UserRoleId))]
        [InverseProperty("Users")]
        public virtual UserRole UserRole { get; set; }
        [InverseProperty(nameof(ShoppingCart.User))]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
