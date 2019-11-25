using System.Collections.Generic;

namespace StartupService.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public CompanyType Type { get; set; }
        public ICollection<Person> Founders { get; set; }

        public Address Location { get; set; }
    }
}