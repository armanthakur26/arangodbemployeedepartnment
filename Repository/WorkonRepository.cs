using ArangoDB.Client;
using Arangodbcompany.Model;
using Arangodbcompany.Repository.IRepository;

namespace Arangodbcompany.Repository
{
    public class WorkonRepository:IWorkonrepository
    {
        private readonly IArangoDatabase _arangodatabase;
        private readonly string _collectionName;
        public WorkonRepository(IArangoDatabase arangoDatabase)
        {
            _arangodatabase = arangoDatabase;
            _collectionName = "Workon";
        }

        public void addWorkRelation(Workon workon)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            collection.Insert(workon);
        }

        public void deleteRelation(string _key)
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var del = collection.Document<Workon>(_key);
            collection.Remove(del);
        }

        public ICollection<Workon> GetWorkRelation()
        {
            var collection = _arangodatabase.Collection(_collectionName);
            var work = collection.All<Workon>().ToList();
            return work ;
        }

       
    }
}
