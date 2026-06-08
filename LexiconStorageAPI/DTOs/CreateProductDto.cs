using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconStorageAPI.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [StringLength(30)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Shelf { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [StringLength(200)]
        public string? Description { get; set; } = string.Empty;
    }
}
