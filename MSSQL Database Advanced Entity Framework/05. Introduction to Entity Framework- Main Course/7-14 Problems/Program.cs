using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;

namespace P02_DatabaseFirst
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var context = new SoftUniContext();
            using (context)
            {
                // 8.Addresses by Town
                //    var addresses = context.Addresses.Include(x=> x.Employees).Include(x=>x.Employees).Include(x=> x.Town)
                //        .OrderByDescending(x => x.Employees.Count)
                //        .ThenBy(x => x.Town.Name)
                //        .ThenBy(x => x.AddressText).Take(10)
                //        .ToList();
                //    foreach (var address in addresses)
                //    {
                //        Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
                //    }

                // 9. Employee 147
                //var employee147 = context.Employees.Include(x => x.EmployeesProjects).ThenInclude(x=> x.Project)
                //    .First(x => x.EmployeeId == 147);
                //Console.WriteLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
                //foreach (var employee147EmployeesProject in employee147.EmployeesProjects.OrderBy(x=> x.Project.Name))
                //{
                //    Console.WriteLine(employee147EmployeesProject.Project.Name);
                //}

                // 10.Departments with More Than 5 Employees
                //var departments = context.Departments.Include(x=> x.Manager).Include(x=> x.Employees).Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count)
                //    .ThenBy(x => x.Name);
                //foreach (var department in departments)
                //{
                //    Console.WriteLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");
                //    foreach (var departmentEmployee in department.Employees.OrderBy(x=> x.FirstName).ThenBy(x=> x.LastName))
                //    {
                //        Console.WriteLine($"{departmentEmployee.FirstName} {departmentEmployee.LastName} - {departmentEmployee.JobTitle}");
                //    }
                //    Console.WriteLine("----------");
                //}

                // 11.Find Latest 10 Projects
                //var last10Projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).OrderBy(x => x.Name).Take(10).ToList();
                //foreach (var project in last10Projects)
                //{
                //    Console.WriteLine($"{project.Name}");
                //    Console.WriteLine($"{project.Description}");
                //    Console.WriteLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
                //}

                // 12.Increase Salaries
                //var employees = context.Employees.Include(x=> x.Department).Where(x =>
                //    new[] {"Engineering", "Tool Design", "Marketing", "Information Services"}.Contains(
                //        x.Department.Name)).ToList();
                //foreach (var employee in employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                //{
                //    employee.Salary = employee.Salary + employee.Salary * 12 / 100;
                //    context.SaveChanges();
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
                //}

                // 13.Find Employees by First Name Starting With Sa
                //var employees = context.Employees.Where(x => x.FirstName.StartsWith("Sa")).OrderBy(x=> x.FirstName).ThenBy(x=> x.LastName).ToList();
                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
                //}

                // 14.Delete Project by Id
                //var project = context.Projects.Find(2);
                //var employeeProject = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();
                //context.EmployeesProjects.RemoveRange(employeeProject);
                //context.Projects.Remove(project);
                //context.SaveChanges();
                //foreach (var project1 in context.Projects.Take(10))
                //{
                //    Console.WriteLine(project1.Name);
                //}
            }
        }
    }
}