using System.Collections.Generic;

namespace CleverCrow.SaveRestore {
    public class Storage<T> : IStorage<T> where T : ISaveRestore {
        private readonly Dictionary<string, T> _entriesById = new Dictionary<string, T>();
        
        public Storage (List<T> entries) {
            entries.ForEach(i => _entriesById[i.Id] = i);
        }
        
        public T GetById (string id) {
            return _entriesById[id];
        }
    }
}
