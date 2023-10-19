using ArangoDB.Client;
using Arangodbcompany.Model;
using Arangodbcompany.Repository.IRepository;

namespace Arangodbcompany.Repository
{
    public class Departmentrepository:IDepartmentrepository
    {
        private readonly IArangoDatabase _arangodatabase;
        private readonly string _collectionName;
        public Departmentrepository(IArangoDatabase arangoDatabase)
        {
            _arangodatabase = arangoDatabase;
            _collectionName = "Department";
        }

        public void AddDepartment(Department department)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            collection.Insert(department);
        }

        public void DeleteDepartment(string _key)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var dep = collection.Document<Department>(_key);
            collection.Remove(dep);
        }

        public Department GetDepartment(string _key)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var department = collection.All<Department>().ToList();
            var dep = department.FirstOrDefault(e => e._key == _key);
            return (dep);
        }

        public ICollection<Department> GetDepartments()
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var department = collection.All<Department>().ToList();
            return department;
        }

        public void UpdateDepartment(Department department)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var dep = collection.Document<Department>(department._key);
            if (department != null)
            {
                dep.name = department.name;
            }
            collection.Update(dep);
        }
    }
}
