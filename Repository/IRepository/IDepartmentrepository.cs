using Arangodbcompany.Model;
namespace Arangodbcompany.Repository.IRepository
{
    public interface IDepartmentrepository
    {
        ICollection<Department> GetDepartments();
        Department GetDepartment(string _key);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(string _key);
    }
}
