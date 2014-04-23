using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSReadTelephoneNumber;

namespace TestReadTelephoneNumber
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReadTelephoneNumber app = new ReadTelephoneNumber();
            String result = app.read("12345678999", "3-4-4");
            Assert.AreEqual("one two three four five six seven eight triple nine", result);
        }


        [TestMethod]
        public void TestMethod2()
        {
            ReadTelephoneNumber app = new ReadTelephoneNumber();
            String result = app.read("15012233444", "3-3-5");
            Assert.AreEqual("one five zero one double two double three triple four",result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            ReadTelephoneNumber app = new ReadTelephoneNumber();
            String result = app.read("12223", " 2-3");
            Assert.AreEqual("one two double two three",result);
        }

    }
}
