using System.Collections.Generic;
using UnityEngine;

namespace CleverCrow.SaveRestore.Examples {
    public class DataManager : MonoBehaviour {
        private string _save;
        private IStorage<DataExample> _storage;
        private SaveRestoreCollection<DataExample> _saveRestore;

        [Tooltip("Storage by ID will be pulled from here")]
        [SerializeField]
        private List<DataExample> _dataLibrary;

        [Tooltip("This data will be converted to live copies")]
        [SerializeField]
        private List<DataExample> _addData;

        [Tooltip("Currently active data")]
        [SerializeField]
        private List<DataExample> _copies = new List<DataExample>();

        private void Awake () {
            _storage = new Storage<DataExample>(_dataLibrary);
            _addData.ForEach(i => _copies.Add(i.GetCopy()));
            _saveRestore = new SaveRestoreCollection<DataExample>(_storage);
        }

        public void Save () {
            _save = _saveRestore.Save(_copies);
        }

        public void Load () {
            _copies = _saveRestore.Load(_save);
        }
    }
}