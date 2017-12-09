using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Employees.Data;
using Employees.DtoModels;

namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);
            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }
    }
}
