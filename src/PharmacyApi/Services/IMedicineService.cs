using PharmacyApi.Dtos;

namespace PharmacyApi.Services;

public interface IMedicineService
{
    Task<List<MedicineResponse>> GetAllAsync();

    Task<MedicineResponse> AddAsync(CreateMedicineRequest request);
}