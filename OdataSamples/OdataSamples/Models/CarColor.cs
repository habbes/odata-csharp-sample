using System.ComponentModel.DataAnnotations;

namespace OdataSamples.Models
{
    public class CarColor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string ColorName { get; set; }
    }
}