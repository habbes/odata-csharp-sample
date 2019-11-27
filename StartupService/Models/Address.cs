namespace StartupService.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return City + "," + Country;
        }
    }
}