using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async
{
    public static class DirectoryGenerator
    {
        /// <summary>
        /// Synchronously returns a mapping from company names to the list of all its employees' full names
        /// </summary>
        public static Dictionary<string, List<string>> GenerateSync()
        {
            var result = new Dictionary<string, List<string>>();

            var companyIds = CompanyDataSource.GetAllCompanyIds();
            foreach (var companyId in companyIds)
            {
                var company = CompanyDataSource.GetCompanyById(companyId);
                var list = new List<string>();

                var usOffice = CompanyDataSource.GetOfficeById(company.USOfficeId);
                foreach (var employeeId in usOffice.EmployeeIds)
                {
                    var employee = CompanyDataSource.GetEmployeeById(employeeId);
                    list.Add($"{employee.FirstName} {employee.LastName}");
                }

                var mxOffice = CompanyDataSource.GetOfficeById(company.MexicoOfficeId);
                foreach (var employeeId in mxOffice.EmployeeIds)
                {
                    var employee = CompanyDataSource.GetEmployeeById(employeeId);
                    list.Add($"{employee.FirstName} {employee.LastName}");
                }

                result[company.Name] = list;
            }

            return result;
        }



        /// <summary>
        /// Asynchronously returns a mapping from company names to the list of all its employees' full names (slow)
        /// </summary>
        public static async Task<Dictionary<string, List<string>>> GenerateAsyncSlow()
        {
            var result = new Dictionary<string, List<string>>();

            var companyIds = await CompanyDataSourceAsync.GetAllCompanyIds();
            foreach (var companyId in companyIds)
            {
                var company = await CompanyDataSourceAsync.GetCompanyById(companyId);
                var list = new List<string>();

                var usOffice = await CompanyDataSourceAsync.GetOfficeById(company.USOfficeId);
                foreach (var employeeId in usOffice.EmployeeIds)
                {
                    var employee = await CompanyDataSourceAsync.GetEmployeeById(employeeId);
                    list.Add($"{employee.FirstName} {employee.LastName}");
                }

                var mxOffice = await CompanyDataSourceAsync.GetOfficeById(company.MexicoOfficeId);
                foreach (var employeeId in mxOffice.EmployeeIds)
                {
                    var employee = await CompanyDataSourceAsync.GetEmployeeById(employeeId);
                    list.Add($"{employee.FirstName} {employee.LastName}");
                }

                result[company.Name] = list;
            }

            return result;
        }



        /// <summary>
        /// Asynchronously returns a mapping from company names to the list of all its employees' full names (fast)
        /// </summary>
        public static async Task<Dictionary<string, List<string>>> GenerateAsyncFast()
        {
            var companyIds = await CompanyDataSourceAsync.GetAllCompanyIds();

            var kvPairTasks = companyIds.Select(EmployeesByCompanyId);

            var kvPairs = await Task.WhenAll(kvPairTasks);

            return kvPairs.ToDictionary(p => p.Key, p => p.Value.Select(e => $"{e.FirstName} {e.LastName}").ToList());
        }

        private static async Task<KeyValuePair<string, List<Employee>>> EmployeesByCompanyId(int id)
        {
            var company = await CompanyDataSourceAsync.GetCompanyById(id);

            var usEmployeesTask = EmployeesByOfficeId(company.USOfficeId);
            var mxEmployeesTask = EmployeesByOfficeId(company.MexicoOfficeId);

            return new KeyValuePair<string, List<Employee>>(company.Name, (await usEmployeesTask).Concat(await mxEmployeesTask).ToList());
        }

        private static async Task<Employee[]> EmployeesByOfficeId(int id)
        {
            var office = await CompanyDataSourceAsync.GetOfficeById(id);

            var employeeTasks = office.EmployeeIds.Select(CompanyDataSourceAsync.GetEmployeeById);

            return await Task.WhenAll(employeeTasks);
        }
    }
}