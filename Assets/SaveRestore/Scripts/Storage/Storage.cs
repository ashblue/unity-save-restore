using System.Collections.Generic;

namespace CleverCrow.SaveRestore {
    public class Storage : IStorage {
        private readonly Dictionary<string, ISaveRestore> _entriesById = new Dictionary<string, ISaveRestore>();
        
        public Storage (List<ISaveRestore> entries) {
            entries.ForEach(i => _entriesById[i.Id] = i);
        }
        
        public ISaveRestore GetById (string id) {
            return _entriesById[id];
        }
    }
}