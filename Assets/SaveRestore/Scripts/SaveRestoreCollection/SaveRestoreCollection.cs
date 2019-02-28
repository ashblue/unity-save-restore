using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace CleverCrow.SaveRestore {
    public class SaveRestoreCollection<T> where T : ISaveRestore, ICopy<T> {
        private readonly IStorage<T> _storage;
        
        public SaveRestoreCollection (IStorage<T> storage) {
            _storage = storage;
        }

        public string Save (IEnumerable<T> items) {
            var save = JsonConvert.SerializeObject(items.Select(i => new SaveContainer {
                save = i.Save(),
                id = i.Id
            }));

            return save;
        }

        public List<T> Load (string save) {
            var data = JsonConvert.DeserializeObject<List<SaveContainer>>(save);
            
            return data.Select(i => {
                var copy = _storage.GetById(i.id).GetCopy();
                copy.Load(i.save);
                
                return copy;
            }).ToList();
        }
    }
}