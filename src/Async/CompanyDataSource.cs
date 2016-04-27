using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public static class CompanyDataSource
    {
        public static int[] GetAllCompanyIds() { Task.Delay(1000).Wait(); return new int[] { 0, 1 }; }
        public static Company GetCompanyById(int id) { Task.Delay(1000).Wait(); return Data.Companies[id]; }
        public static Office GetOfficeById(int id) { Task.Delay(1000).Wait(); return Data.Offices[id]; }
        public static Employee GetEmployeeById(int id) { Task.Delay(1000).Wait(); return Data.Employees[id]; }
    }
}