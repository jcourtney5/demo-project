using Api.Models;

namespace UnitTests;

public static class Utils
{
    public static Employee CreateTestEmployee(decimal salary = 52000m, int age = 30, int numDependents = 0)
    {
        var employee = new Employee()
        {
            Id = 1,
            FirstName = "Jon",
            LastName = "Smith",
            Salary = salary,
            DateOfBirth = DateTime.Today.AddYears(-age),
            Dependents = new List<Dependent>()
        };

        for (var i = 0; i < numDependents; i++)
        {
            var dependent = new Dependent()
            {
                Id = i + 1,
                FirstName = $"Depended {i + 1}",
                LastName = employee.LastName,
                DateOfBirth = DateTime.Today.AddYears(-10),
                Relationship = Relationship.Child,
                EmployeeId = 1
            };
            employee.Dependents.Add(dependent);
        }
        
        return employee;
    }

    public static void AddPartner(Employee employee, Relationship relationship)
    {
        int id = employee.Dependents.Any()
            ? employee.Dependents.Max(x => x.Id) + 1
            : 1;
        
        employee.Dependents.Add(new Dependent()
        {
            Id = id,
            FirstName = relationship == Relationship.Spouse ? "Spouse" : "Domestic Partner",
            LastName = employee.LastName,
            DateOfBirth = DateTime.Today.AddYears(-20),
            Relationship = relationship,
            EmployeeId = employee.Id
        });
    }
}