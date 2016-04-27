using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async
{
    public class Data
    {
        public static readonly Company[] Companies = new Company[]
        {
            new Company
            {
                Id = 0,
                Name = "SolarCity",
                USOfficeId = 0,
                MexicoOfficeId = 1
            },
            new Company
            {
                Id = 1,
                Name = "Microsoft",
                USOfficeId = 2,
                MexicoOfficeId = 3
            }
        };

        public static readonly Office[] Offices = new Office[]
        {
            new Office
            {
                Id = 0,
                EmployeeIds = new int[] { 0, 1 }
            },
            new Office
            {
                Id = 1,
                EmployeeIds = new int[] { 2, 3 }
            },
            new Office
            {
                Id = 2,
                EmployeeIds = new int[] { 4 }
            },
            new Office
            {
                Id = 3,
                EmployeeIds = new int[] { 5 }
            }
        };

        public static readonly Employee[] Employees = new Employee[]
        {
            new Employee { Id = 0, FirstName = "Aaron", LastName = "Kahn" },
            new Employee { Id = 1, FirstName = "Katie", LastName = "DeWitt" },
            new Employee { Id = 2, FirstName = "Greg", LastName = "Laabs" },
            new Employee { Id = 3, FirstName = "Ava", LastName = "Hristova" },
            new Employee { Id = 4, FirstName = "Satya", LastName = "Nadella" },
            new Employee { Id = 5, FirstName = "Anders", LastName = "Hejlsberg" }
        };
    }
}