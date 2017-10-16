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
        public void cuando_transformo_un_string_queda_el_mismo()
        {
            SimpleTransformator transformator = new SimpleTransformator();

            String result = transformator.Transform("One Ring to rule them all, One Ring to find them");

            Assert.AreEqual("One Ring to rule them all, One Ring to find them", result);
        }

        [TestMethod]
        public void cuando_transformo_un_string_vacio_devuelvo_un_string_vacio()
        {
            SimpleTransformator transformator = new SimpleTransformator();

            String result = transformator.Transform("");

            Assert.AreEqual("", result);
        }
    }
}
