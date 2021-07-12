using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.Xml.MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Student student = new Student();
            student.Name = "Tom";

            var text = XmlConvert.SerializeObject(student);

            var actual = XmlConvert.DeserializeObject<Student>(text);

            Assert.AreEqual(student.Name, actual.Name);
        }
    }
}
