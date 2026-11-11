using Patient.Domain.Common;
using Patient.Domain.Enums;

namespace Patient.Domain.Entities;

public class PatientRecord : BaseModel
{
    public required string FileNo { get; set; }
    public string? NationalId { get; set; }
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string? BloodGroup { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
