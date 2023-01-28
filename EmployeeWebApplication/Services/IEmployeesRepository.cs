using EmployeesWebApplication.Models;

namespace EmployeesWebApplication.Services
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAll();

        Employee? GetById(int Id);

        int Add(Employee item);

        bool Edit(Employee item);

        bool Remove(int Id);
    }
}
