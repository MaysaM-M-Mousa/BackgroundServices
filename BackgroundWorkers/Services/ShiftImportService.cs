using BackgroundWorkers.Models;
using BackgroundWorkers.Repositories;

namespace BackgroundWorkers.Services;

public class ShiftImportService : IShiftImportService
{
    private readonly IShiftRepository _shiftRepository;
    private readonly HttpClient _httpClient;

    public ShiftImportService(IShiftRepository shiftRepository, HttpClient httpClient)
    {
        _shiftRepository = shiftRepository;
        _httpClient = httpClient;
    }

    public async Task ImportShifts()
    {
        var response = await _httpClient.GetAsync("/ThirdParty/shifts/import");

        var importedShifts = await response.Content.ReadFromJsonAsync<List<Shift>>();

        _shiftRepository.AddBatchShifts(importedShifts);
    }
}
