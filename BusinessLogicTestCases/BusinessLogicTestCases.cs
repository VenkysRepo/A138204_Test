using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Interfaces;
using BusinessLayer.Interfaces;
using Rhino.Mocks;
using MvcContrib.TestHelper;
using BusinessLayer.Classes;
using Models.Domain_Models;
using System.Collections.Generic;
using Models.View_Models;

namespace BusinessLogicTestCases
{
    [TestClass]
    public class BusinessLogicTestCases
    {
        private IGetPetsJson Getdata;
        private readonly TestControllerBuilder builder;
        /// <summary>The account controller.</summary>
        private readonly IExtractPetsBusinessLogic extractData;
        public BusinessLogicTestCases()
        {

            this.Getdata = MockRepository.GenerateStub<IGetPetsJson>();
            this.builder = new TestControllerBuilder();
            this.extractData = new ExtractPetsBusinessLogic(Getdata);
        }
        [TestMethod]
        public void BusinessLayerNullReturn()
        {
            // Act
            var result = this.extractData.getSortedPetsbyGender();
            this.Getdata.Stub(s => s.getJsonData()).Return(null);
            // Assert
            Assert.IsNull(result);
            Assert.IsInstanceOfType(result, typeof(Nullable));
        }

        [TestMethod]
        public void BusinessLayerNotNullReturn()
        {
            var sortedPetsListbyGender = new SortedPetsListbyGender { Gender = "Female", petsList = new List<string> { "Simba", "Nemo" } };
            var sortedPetsListbyGenderList = new List<SortedPetsListbyGender> { sortedPetsListbyGender };
            var pet = new Pet { name = "Simba", type = "Fish" };
            var petList = new PetJson { pets = new List<Pet> { pet }, name = "Mono", age = 1, gender = "Female" };
            var petjsonList = new List<PetJson> { petList };
            // Act
            this.Getdata.Stub(s => s.getJsonData()).Return(petjsonList);
            // Assert
            var result = this.extractData.getSortedPetsbyGender();

            Assert.IsNull(result);
            Assert.IsInstanceOfType(result, typeof(List<SortedPetsListbyGender>));
            Assert.IsTrue(result.SortedList.Count > 0);
        }
    }
}
