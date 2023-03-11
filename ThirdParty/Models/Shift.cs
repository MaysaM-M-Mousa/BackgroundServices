namespace ThirdParty.Models;

public class Shift
{
    public Guid Id { get; set; }

    public Guid? EmployeeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? PayRate { get; set; }
}
