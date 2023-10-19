using Arangodbcompany.Model;

namespace Arangodbcompany.Repository.IRepository
{
    public interface Iemployeerepository
    {
        ICollection<Employee> GetEmployees();

        Employee getemploye(string _key);
        void addemployee(Employee employee);
        void updateemployee(Employee employee);
        void deleteemployee(string _key);
    }
}
