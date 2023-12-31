﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        public float? Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
