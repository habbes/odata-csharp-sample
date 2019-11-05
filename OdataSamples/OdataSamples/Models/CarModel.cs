using System.ComponentModel.DataAnnotations;

namespace OdataSamples.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string ModelName { get; set; }
    }
}