using Microsoft.AspNetCore.Mvc;
using PharmacyApi.Dtos;
using PharmacyApi.Services;

namespace PharmacyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicineController : ControllerBase
{
    private readonly IMedicineService _medicineService;

    public MedicineController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    [HttpGet]
    public async Task<ActionResult<List<MedicineResponse>>> GetMedicines()
    {
        var medicines = await _medicineService.GetAllAsync();

        return Ok(medicines);
    }

    [HttpPost]
    public async Task<ActionResult<MedicineResponse>> AddMedicine(CreateMedicineRequest request)
    {
        var medicine = await _medicineService.AddAsync(request);

        return CreatedAtAction(nameof(GetMedicines), new { id = medicine.Id }, medicine);
    }
}