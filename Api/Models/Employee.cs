namespace Api.Models;

public class Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    public int GetAgeAsOfToday()
    {
        // Only gets age as of today which is flawed for paycheck calculations
        var age = DateTime.Today.Year - DateOfBirth.Year;
        if (DateOfBirth > DateTime.Today.AddYears(-age)) age--;
        return age;
    }

    public int GetNumberOfChildren()
    {
        return Dependents.Count(d => d.Relationship == Relationship.Child);
    }
}
