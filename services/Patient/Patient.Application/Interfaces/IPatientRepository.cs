using Patient.Domain.Entities;

namespace Patient.Application.Interfaces;

public interface IPatientRepository
{
    Task<PatientRecord?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PatientRecord?> GetByFileNoAsync(string fileNo, CancellationToken cancellationToken = default);
    Task<bool> FileNoExistsAsync(string fileNo, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PatientRecord>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task AddAsync(PatientRecord patient, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
