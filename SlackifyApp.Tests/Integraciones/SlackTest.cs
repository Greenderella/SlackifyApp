using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackifyApp;
using SlackifyApp.Controllers;

namespace SlackifyApp.Tests.Integraciones
{
    [TestClass]
    public class SlackTest
    {
        [TestMethod]
        public void CuandoSeEjecutaElSlashCommandSlackNosEnviaUnObjetoConTokenComandoResponseURLyTexto()
        {
            // Arrange
            Slack slack = new Slack();


            // Act
            DatosSalientes datosSalientes = slack.EjecutarSlashCommand();


            // Assert
            Assert.IsNotNull(datosSalientes.Token);
            Assert.IsNotNull(datosSalientes.Command);
            Assert.IsNotNull(datosSalientes.ResponseURL);
            Assert.IsNotNull(datosSalientes.Text);
        }
    }
}
