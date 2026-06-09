using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconStorageAPI.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [MaxLength(30)]
        public string Category { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Shelf { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; } = string.Empty;
    }
}
