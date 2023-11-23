using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        public float? Price { get; set; }

        public DateTime? CreatedAt { get; set; } = default(DateTime?);

    }
}
