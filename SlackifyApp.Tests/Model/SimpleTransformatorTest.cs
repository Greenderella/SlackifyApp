using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackifyApp;
using SlackifyApp.Model;

namespace SlackifyApp.Tests.Model
{
    [TestClass]
    public class SimpleTransformatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimpleTransformator transformator = new SimpleTransformator();

            String result = transformator.transform("sarlanga");

            Assert.AreEqual("sarlanga", result);
        }
    }
}
