using Api.Models;

namespace Api.Data;

public class EmployeeData
{
    private readonly List<Employee> _employees;

    public EmployeeData()
    {
        // Simple in memory data store for employees with embedded dependents
        _employees = new List<Employee>()
        {
            new()
            {
                Id = 1,
                FirstName = "LeBron",
                LastName = "James",
                Salary = 75420.99m,
                DateOfBirth = new DateTime(1984, 12, 30)
            },
            new()
            {
                Id = 2,
                FirstName = "Ja",
                LastName = "Morant",
                Salary = 92365.22m,
                DateOfBirth = new DateTime(1999, 8, 10),
                Dependents = new List<Dependent>
                {
                    new()
                    {
                        Id = 1,
                        FirstName = "Spouse",
                        LastName = "Morant",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1998, 3, 3),
                        EmployeeId = 2
                    },
                    new()
                    {
                        Id = 2,
                        FirstName = "Child1",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2020, 6, 23),
                        EmployeeId = 2
                    },
                    new()
                    {
                        Id = 3,
                        FirstName = "Child2",
                        LastName = "Morant",
                        Relationship = Relationship.Child,
                        DateOfBirth = new DateTime(2021, 5, 18),
                        EmployeeId = 2
                    }
                }
            },
            new()
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Jordan",
                Salary = 143211.12m,
                DateOfBirth = new DateTime(1963, 2, 17),
                Dependents = new List<Dependent>
                {
                    new()
                    {
                        Id = 4,
                        FirstName = "DP",
                        LastName = "Jordan",
                        Relationship = Relationship.DomesticPartner,
                        DateOfBirth = new DateTime(1974, 1, 2),
                        EmployeeId = 3
                    }
                }
            }
        };
    }

    public Task<List<Employee>> GetEmployeesAsync()
    {
        return Task.FromResult(_employees);
    }

    public Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
    }

    public Task<List<Dependent>> GetDependentsAsync()
    {
        // Not very efficient but works for testing small amounts of data
        var dependents = _employees.SelectMany(e => e.Dependents).ToList();
        return Task.FromResult(dependents);
    }

    public Task<Dependent?> GetDependentByIdAsync(int dependentId)
    {
        // Also not very efficient but works for testing small amounts of data
        var dependent = _employees.SelectMany(e => e.Dependents).FirstOrDefault(d => d.Id == dependentId);
        return Task.FromResult(dependent);
    }
}