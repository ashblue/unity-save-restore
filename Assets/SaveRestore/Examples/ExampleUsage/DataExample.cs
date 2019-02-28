using Newtonsoft.Json;
using UnityEngine;

namespace CleverCrow.SaveRestore.Examples {
    [CreateAssetMenu(fileName = "Data", menuName = "CleverCrow/Data")]
    public class DataExample : ScriptableObject, ISaveRestore, ICopy<DataExample> {
        [SerializeField]
        private string _text;
        
        [SerializeField]
        private int _number;
        
        public string Id => name.Replace("(Clone)", "");
        
        private class SaveData {
            public string text;
            public int number;
        }
        
        public string Save () {
            return JsonConvert.SerializeObject(new SaveData {
                text = _text,
                number = _number
            });
        }

        public void Load (string save) {
            var data = JsonConvert.DeserializeObject<SaveData>(save);

            _text = data.text;
            _number = data.number;
        }

        public DataExample GetCopy () {
            return Instantiate(this);
        }
    }
}
