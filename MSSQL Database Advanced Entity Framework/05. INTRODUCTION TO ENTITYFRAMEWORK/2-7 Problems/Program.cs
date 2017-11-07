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
                // 3. Employees Full Information
                //
                //var employeesFullInfo = context.Employees;
                //foreach (var employee in employeesFullInfo)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
                //}

                // 4. Employees with Salary Over 50 000
                //var employeesSalaryOver = context.Employees.Where(e => e.Salary > 50000).OrderBy(e=> e.FirstName).ToList();
                //foreach (var employee in employeesSalaryOver)
                //{
                //    Console.WriteLine(employee.FirstName);
                //}

                // 5. Employees from Research and Development
                //
                //var employeesFromResearch = context.Employees.Where(e => e.Department.Name == "Research and Development").OrderBy(em => em.Salary).ThenByDescending(x => x.FirstName)
                //    .ToList();
                //foreach (var employee in employeesFromResearch)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
                //}

                // 6. Adding a New Address and Updating Employee
                //var newAddress = new Address();
                //newAddress.AddressText = "Vitoshka 15";
                //newAddress.TownId = 4;
                //var employeeNakov = context.Employees.First(x => x.LastName == "Nakov");
                //employeeNakov.Address = newAddress;
                //context.SaveChanges();
                //var addresses = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address.AddressText);
                //foreach (var address in addresses)
                //{
                //    Console.WriteLine(address);
                //}

                // 7. Employees and Projects
                //var employees = context.Employees.Include(e => e.EmployeesProjects).ThenInclude(ep => ep.Project)
                //    .Where(p => p.EmployeesProjects.Any(x =>
                //        x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003)).Take(30)
                //        .Select(e => new
                //        {
                //            e.FirstName,
                //            e.LastName,
                //            e.Manager,
                //            e.EmployeesProjects
                //        }).ToList();
                //
                //foreach (var employee in employees)
                //{
                //    Console.WriteLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");
                //    foreach (var p in employee.EmployeesProjects)
                //    {
                //        string format = "M/d/yyyy h:mm:ss tt";
                //
                //        string startDate = p.Project.StartDate.ToString(format, CultureInfo.InvariantCulture);
                //        string endDate = p.Project.EndDate.ToString();
                //
                //        if (string.IsNullOrWhiteSpace(endDate))
                //        {
                //            endDate = "not finished";
                //        }
                //        else
                //        {
                //            endDate = p.Project.EndDate.Value.ToString(format, CultureInfo.InvariantCulture);
                //        }
                //
                //        Console.WriteLine($"--{p.Project.Name} - {startDate} - {endDate}");
                //    }
                //}
            }
        }
    }
}