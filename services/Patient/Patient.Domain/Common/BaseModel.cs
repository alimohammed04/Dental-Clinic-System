namespace Patient.Domain.Common;

public abstract class BaseModel
{
    public int Id { get; protected set; }
    public bool IsDeleted { get; set; }
    public required string CreationUser { get; set; }
    public DateTime CreationDate { get; set; }
    public string? ModificationUser { get; set; }
    public DateTime? ModificationDate { get; set; }
}
