﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackifyApp;
using SlackifyApp.Controllers;

namespace SlackifyApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Configure()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Configure() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.Endpoint);
        }
    }
}
