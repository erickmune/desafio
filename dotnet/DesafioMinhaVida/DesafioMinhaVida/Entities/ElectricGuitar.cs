using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMinhaVida.Entities
{
    public class ElectricGuitar
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(400)]
        public string Name { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, StringLength(1000)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        public string SKU { get; set; }
    }
}
