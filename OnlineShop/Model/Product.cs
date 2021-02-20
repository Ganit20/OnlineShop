using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OnlineShop.Model
{
    public partial class Product
    {
        public Product()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string ProductImageUrl { get; set; }
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category ProductCategory { get; set; }
        [InverseProperty(nameof(ShoppingCart.Product))]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
