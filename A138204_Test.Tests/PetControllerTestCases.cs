using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Interfaces;
using A138204_Test.Controllers;
using MvcContrib.TestHelper;
using System.Web.Mvc;
using Models.View_Models;

namespace A138204_Test.Tests
{
    [TestClass]
    public class PetControllerTestCases
    {
        private IExtractPetsBusinessLogic extractData;
        private readonly TestControllerBuilder builder;
        /// <summary>The account controller.</summary>
        private readonly PetsController petController;
        [TestMethod]
        public void TestMethod1()
        {
            // Act
            var result = petController.Pets() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("~/Views/Pets/Pets.cshtml", result.ViewName);
        }

        [TestMethod]

        public void TestMethod2()
        {
            // Act
            var result = this.petController.Pets() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var product = (ListofPets)result.ViewData.Model;
            Assert.IsNotNull(product);
        }
    }
}
