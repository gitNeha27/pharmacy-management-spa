using PharmacyApi.Models;

namespace PharmacyApi.Repositories;

public interface IMedicineRepository
{
    Task<List<Medicine>> GetAllAsync();

    Task<Medicine> AddAsync(Medicine medicine);
}