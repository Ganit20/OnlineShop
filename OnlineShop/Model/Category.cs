using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace OnlineShop.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Product.ProductCategory))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
