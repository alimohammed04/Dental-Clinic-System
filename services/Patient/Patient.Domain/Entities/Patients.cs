using Patient.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Domain.Entities
{
    public class Patients : BaseModel
    {
        public string FileNo { get; set; }
        public string? NationalId { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
