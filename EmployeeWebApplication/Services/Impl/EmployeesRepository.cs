using EmployeesWebApplication.Models;

namespace EmployeesWebApplication.Services.Impl
{
    public class EmployeesRepository : IEmployeesRepository
    {

        private readonly List<Employee> _Employees;
        private int _MaxFreeId;

        public EmployeesRepository()
        {
            _Employees = Enumerable.Range(1, 10)
                .Select(i => new Employee
                {
                    Id = i,
                    LastName = $"Фамилия-{i}",
                    FirstName = $"Имя-{i}",
                    Patronymic = $"Отчество-{i}",
                    Birthday = DateTime.Now.AddYears(-18 - i)
                }).ToList();
            _MaxFreeId = _Employees.Max(e => e.Id) + 1;
        }

        public IEnumerable<Employee> GetAll() => _Employees;

        public int Add(Employee item)
        {
            item.Id = _MaxFreeId;
            _MaxFreeId++;
            _Employees.Add(item);
            return item.Id;
        }

        public bool Edit(Employee item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null)
                return false;

            db_item.LastName = item.LastName;
            db_item.FirstName = item.FirstName;
            db_item.Patronymic = item.Patronymic;
            db_item.Birthday = item.Birthday;

            return true;
        }

        public Employee? GetById(int Id) => _Employees.FirstOrDefault(item => item.Id == Id);

        public bool Remove(int Id)
        {
            var db_item = GetById(Id);
            if (db_item is null)
                return false;

            _Employees.Remove(db_item);
            return true;
        }
    }
}
