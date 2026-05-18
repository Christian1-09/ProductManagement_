using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement_.Features.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; } = 0;

        [MaxLength(50)]
        public string? SKU { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Foreign Keys (Link to other tables)
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int SupplierId { get; set; }

        // Navigation Properties
        public Category Category { get; set; } = null!;
        public Brand Brand { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
    }
}
