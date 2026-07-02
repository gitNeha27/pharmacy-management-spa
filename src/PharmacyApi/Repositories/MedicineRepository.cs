using System.Text.Json;
using PharmacyApi.Models;

namespace PharmacyApi.Repositories;

public class MedicineRepository : IMedicineRepository
{
    private readonly string _filePath;

    public MedicineRepository()
    {
        _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "medicines.json");
    }

    public async Task<List<Medicine>> GetAllAsync()
    {
        if (!File.Exists(_filePath))
            return new List<Medicine>();

        var json = await File.ReadAllTextAsync(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return new List<Medicine>();

        return JsonSerializer.Deserialize<List<Medicine>>(json)
               ?? new List<Medicine>();
    }

    public async Task<Medicine> AddAsync(Medicine medicine)
    {
        var medicines = await GetAllAsync();

        medicine.Id = medicines.Any()
            ? medicines.Max(x => x.Id) + 1
            : 1;

        medicines.Add(medicine);

        var json = JsonSerializer.Serialize(
            medicines,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(_filePath, json);

        return medicine;
    }
}