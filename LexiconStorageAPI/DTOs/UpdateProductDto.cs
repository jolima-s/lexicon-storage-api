using System.ComponentModel.DataAnnotations;

namespace LexiconStorageAPI.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

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
