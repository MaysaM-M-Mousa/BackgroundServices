using BackgroundWorkers.Models;

namespace BackgroundWorkers.Services;

public interface IShiftService
{
    Shift GetShiftById(Guid Id);

    List<Shift> GetAllShifts();

    void CreateShift(Shift shift);

    void DeleteShift(Guid ShiftId);
}
