using BackgroundWorkers.Models;

namespace BackgroundWorkers.Services;

public interface IShiftImportService
{
    Task ImportShifts();
}
