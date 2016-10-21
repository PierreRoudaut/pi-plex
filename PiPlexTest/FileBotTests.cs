using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiPlex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PiPlex.Tests
{
    [TestClass()]
    public class FileBotTests
    {
        [TestMethod()]
        public void SampleMethodTest()
        {
            var fb = new PiPlex.FileBot
            {
                SomeString = "HELLO"
            };
            Assert.AreEqual("_HELLO_", fb.SomeString);
        }

        [TestMethod()]
        public void FetchSubtitlesTest()
        {
            Assert.IsTrue(PiPlex.FileBot.SampleMethod());
        }
    }
}
