using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Employees.DtoModels;
using Employees.Models;

namespace Employee.App
{
    class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employees.Models.Employee, EmployeeDto>();
        }
    }
}
