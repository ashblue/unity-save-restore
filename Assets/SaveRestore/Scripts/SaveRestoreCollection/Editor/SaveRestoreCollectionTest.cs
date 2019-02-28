using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;

namespace CleverCrow.SaveRestore.Editors {
    public class SaveRestoreCollectionTest {
        private IStorage _storage;
        private SaveRestoreCollection _saveRestore;
        private ISaveRestore _obj;
        private List<ISaveRestore> _list;
        
        [SetUp]
        public void BeforeEach () {
            _storage = Substitute.For<IStorage>();
            _saveRestore = new SaveRestoreCollection(_storage);
            
            _obj = Substitute.For<ISaveRestore>();
            _obj.Save().Returns((x) => "asdf");
            _obj.Id.Returns((x) => "id");
            
            _list = new List<ISaveRestore> {_obj};
        }
        
        public class SaveMethod : SaveRestoreCollectionTest {
            [Test]
            public void It_should_store_the_parameters_in_a_SaveContainer_before_serialization () {
                var save = _saveRestore.Save(_list);
                var expected = JsonConvert.SerializeObject(_list.Select(i => new SaveContainer {
                    save = i.Save(),
                    id = i.Id
                }));
            
                Assert.AreEqual(expected, save);
            }
        }

        public class LoadMethod : SaveRestoreCollectionTest {
            [Test]
            public void It_should_return_a_list_of_copies_from_storage () {
                var saveRestoreCopy = Substitute.For<ISaveRestore>();
                
                _obj.GetCopy().Returns((x) => saveRestoreCopy);
                _storage.GetById("id").Returns(x => _obj);

                var save = _saveRestore.Save(_list);
                var load = _saveRestore.Load(save);

                for (var i = 0; i < _list.Count; i++) {
                    Assert.AreEqual(load[i], _list[i].GetCopy());
                }
            }
            
            [Test]
            public void It_should_inject_the_save_string_into_Load_on_the_copy () {
                var saveRestoreCopy = Substitute.For<ISaveRestore>();
                
                _obj.GetCopy().Returns((x) => saveRestoreCopy);
                _storage.GetById("id").Returns(x => _obj);

                var save = _saveRestore.Save(_list);
                var load = _saveRestore.Load(save);

                foreach (var i in _list) {
                    i.GetCopy().Received(1).Load(i.Save());
                }
            }
        }
    }
}
