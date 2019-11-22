using System.Collections.Generic;

namespace StartupService.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public CompanyType Type { get; set; }
        public List<Person> Founders;

        public Address Location { get; set; }
    }
}