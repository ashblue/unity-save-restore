using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CleverCrow.SaveRestore {
    public class SaveRestoreCollection {
        public string Save(IEnumerable<ISaveRestore> items) {
            var save = JsonUtility.ToJson(items.Select(i => i.Save()));
            Debug.Log(save);

            return save;
        }
    }
}