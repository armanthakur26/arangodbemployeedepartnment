using Arangodbcompany.Model;

namespace Arangodbcompany.Repository.IRepository
{
    public interface IWorkonrepository
    {
        ICollection<Workon> GetWorkRelation();
        void addWorkRelation(Workon workon);
        void deleteRelation(string _key);
    }
}
