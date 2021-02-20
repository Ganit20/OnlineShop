using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OnlineShop.Model
{
    public partial class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ShoppingCarts")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("ShoppingCarts")]
        public virtual User User { get; set; }
    }
}
