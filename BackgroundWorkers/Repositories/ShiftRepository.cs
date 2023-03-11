using BackgroundWorkers.Models;

namespace BackgroundWorkers.Repositories;

public class ShiftRepository : IShiftRepository
{
    private List<Shift> Shifts { get; set; } = new List<Shift>()
    {
        new Shift() { Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(5), PayRate = 15 },
        new Shift() { Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(1), PayRate = 12.3m },
        new Shift() { Id = Guid.NewGuid(), EmployeeId = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(4), PayRate = 10.5m }

    };

    public void AddBatchShifts(List<Shift> batchShifts)
    {
        Shifts.AddRange(batchShifts);
    }

    public void CreateShift(Shift shift)
    {
        Shifts.Add(shift);
    }

    public void DeleteShift(Guid shiftId)
    {
        Shifts = Shifts.Where(_ => _.Id != shiftId).ToList();
    }

    public List<Shift> GetAllShifts()
    {
        return Shifts;
    }

    public Shift GetShiftById(Guid Id)
    {
        return Shifts.FirstOrDefault(_ => _.Id == Id);
    }
}
