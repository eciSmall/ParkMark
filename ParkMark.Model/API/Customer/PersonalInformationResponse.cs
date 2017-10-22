using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Model.API.Customer
{
    public class PersonalInformationResponse
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public int Credit { get; set; }
        public string Plate { get; set; }
        public int Authorization { get; set; }
    }
}
