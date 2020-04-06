using System.Collections.Generic;

namespace WebStore.Interfaces.Services
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        void Add(Employee employee);

        void Edit(int id, Employee employee);

        bool Delete(int id);

        void SaveChanges();


    }
}
