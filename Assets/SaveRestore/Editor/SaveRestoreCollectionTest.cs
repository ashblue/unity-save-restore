using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace CleverCrow.SaveRestore {
    public class SaveRestoreCollectionTest {
        [Test]
        public void It_should_return_the_passed_array_as_a_string () {
            var saveRestore = new SaveRestoreCollection();
            var obj = Substitute.For<ISaveRestore>();
            obj.Save().Returns((x) => "asdf");

            var save = saveRestore.Save(new List<ISaveRestore>{obj});
            
            Assert.AreEqual(1, save.Length);
            Assert.AreEqual("asdf", save[0]);
        }
    }
}
