using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace CleverCrow.SaveRestore.Editors {
    public class StorageTest {
        public class GetByIdMethod {
            [Test]
            public void It_should_retrieve_the_stored_object_by_id () {
                var entry = Substitute.For<ISaveRestore>();
                entry.Id.Returns(x => "id");

                var storage = new Storage(new List<ISaveRestore>{entry});
                
                Assert.AreEqual(entry, storage.GetById("id"));
            }
        }
    }
}