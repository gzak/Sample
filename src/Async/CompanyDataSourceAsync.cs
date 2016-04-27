using System.Threading.Tasks;

namespace Async
{
    public static class CompanyDataSourceAsync
    {
        public static async Task<int[]> GetAllCompanyIds() { await Task.Delay(1000); return new int[] { 0, 1 }; }
        public static async Task<Company> GetCompanyById(int id) { await Task.Delay(1000); return Data.Companies[id]; }
        public static async Task<Office> GetOfficeById(int id) { await Task.Delay(1000); return Data.Offices[id]; }
        public static async Task<Employee> GetEmployeeById(int id) { await Task.Delay(1000); return Data.Employees[id]; }
    }
}