using PharmacyApi.Dtos;
using PharmacyApi.Models;
using PharmacyApi.Repositories;

namespace PharmacyApi.Services;

public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _repository;

    public MedicineService(IMedicineRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedicineResponse>> GetAllAsync()
    {
        var medicines = await _repository.GetAllAsync();

        return medicines.Select(m => new MedicineResponse
        {
            Id = m.Id,
            FullName = m.FullName,
            Notes = m.Notes,
            ExpiryDate = m.ExpiryDate,
            Quantity = m.Quantity,
            Price = m.Price,
            Brand = m.Brand
        }).ToList();
    }

    public async Task<MedicineResponse> AddAsync(CreateMedicineRequest request)
    {
        var medicine = new Medicine
        {
            FullName = request.FullName,
            Notes = request.Notes,
            ExpiryDate = request.ExpiryDate,
            Quantity = request.Quantity,
            Price = request.Price,
            Brand = request.Brand
        };

        var savedMedicine = await _repository.AddAsync(medicine);

        return new MedicineResponse
        {
            Id = savedMedicine.Id,
            FullName = savedMedicine.FullName,
            Notes = savedMedicine.Notes,
            ExpiryDate = savedMedicine.ExpiryDate,
            Quantity = savedMedicine.Quantity,
            Price = savedMedicine.Price,
            Brand = savedMedicine.Brand
        };
    }
}