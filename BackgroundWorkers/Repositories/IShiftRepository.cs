using BackgroundWorkers.Models;

namespace BackgroundWorkers.Repositories;

public interface IShiftRepository
{
    Shift GetShiftById(Guid Id);

    List<Shift> GetAllShifts();

    void CreateShift(Shift shift);

    void DeleteShift(Guid shiftId);

    void AddBatchShifts(List<Shift> batchShifts);
}
