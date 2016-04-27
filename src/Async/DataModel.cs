namespace Async
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int USOfficeId { get; set; }
        public int MexicoOfficeId { get; set; }
    }

    public class Office
    {
        public int Id { get; set; }
        public int[] EmployeeIds { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}