using System;
using Xunit;
using TestingQuest_18jule;

namespace TestingQuest_18jule.Tests
{
    public class EmployeeManagerTests
    {
        private static EmployeeManager CreateManagerWithSampleData()
        {
            var manager = new EmployeeManager();
            var employee1 = new Employee(1, "John", "Doe", 50000m);
            var employee2 = new Employee(2, "Jane", "Doe", 60000m);
            manager.AddEmployee(employee1);
            manager.AddEmployee(employee2);
            return manager;
        }

        [Fact]
        public void AddEmployee_ShouldAddEmployeeToList()
        {
            // Arrange
            var manager = new EmployeeManager();
            var employee = new Employee(3, "New", "Employee", 70000m);

            // Act
            manager.AddEmployee(employee);

            // Assert
            Assert.Contains(employee, manager.employeesList);
        }

        [Fact]
        public void RemoveEmployee_ShouldRemoveEmployeeFromList()
        {
            // Arrange
            var manager = CreateManagerWithSampleData();
            var employee = manager.GetEmployee(1);

            // Act
            manager.RemoveEmployee(employee.Id);

            // Assert
            Assert.DoesNotContain(employee, manager.employeesList);
        }

        [Fact]
        public void UpdateEmployee_ShouldUpdateEmployeeDetails()
        {
            // Arrange
            var manager = CreateManagerWithSampleData();

            // Act
            manager.UpdateEmployee(1, "FirstName", "Jane");

            // Assert
            var updatedEmployee = manager.GetEmployee(1);
            Assert.Equal("Jane", updatedEmployee.FirstName);
        }

        [Fact]
        public void GetNextFreeId_ShouldReturnFirstFreeId()
        {
            // Arrange
            var manager = CreateManagerWithSampleData();

            // Act
            var nextFreeId = manager.GetNextFreeId();

            // Assert
            Assert.Equal(4, nextFreeId);
        }
    }
}
