using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CleverCrow.SaveRestore {
    public class SaveRestoreCollection {
        private readonly IStorage _storage;
        
        public SaveRestoreCollection (IStorage storage) {
            _storage = storage;
        }

        public string Save (IEnumerable<ISaveRestore> items) {
            var save = JsonConvert.SerializeObject(items.Select(i => new SaveContainer {
                save = i.Save(),
                id = i.Id
            }));

            return save;
        }

        public List<ISaveRestore> Load (string save) {
            var data = JsonConvert.DeserializeObject<List<SaveContainer>>(save);
            
            return data.Select(i => {
                var copy = _storage.GetById(i.id).GetCopy();
                copy.Load(i.save);
                
                return copy;
            }).ToList();
        }
    }
}