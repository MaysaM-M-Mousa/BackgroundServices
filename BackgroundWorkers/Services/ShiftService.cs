using BackgroundWorkers.Models;
using BackgroundWorkers.Repositories;

namespace BackgroundWorkers.Services;

public class ShiftService : IShiftService
{
    private readonly IShiftRepository _shiftRepository;

    public ShiftService(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }

    public void CreateShift(Shift shift)
    {
        shift.Id = Guid.NewGuid();
        shift.EmployeeId = Guid.NewGuid();
        _shiftRepository.CreateShift(shift);
    }

    public void DeleteShift(Guid ShiftId)
    {
        _shiftRepository.DeleteShift(ShiftId);
    }

    public List<Shift> GetAllShifts()
    {
        return _shiftRepository.GetAllShifts();
    }

    public Shift GetShiftById(Guid Id)
    {
        return _shiftRepository.GetShiftById(Id);
    }
}
