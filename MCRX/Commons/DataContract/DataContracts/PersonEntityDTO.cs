using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.DataContracts
{
    public class PersonEntityDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DayOfBirth { get; set; }
        public int Age { get; set; }
    }
}
