using System.ComponentModel.DataAnnotations;

namespace OdataSamples.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public int CarColorId { get; set; }
        public int Year { get; set; }

        public double CarValue { get; set; }

        public CarModel CarModel { get; set; }

        public CarColor CarColor { get; set; }
    }
}