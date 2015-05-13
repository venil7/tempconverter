using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TempConverter.Services;
using System.Collections.Generic;

namespace TempConverter.Tests
{
    [TestClass]
    public class TempStorageTest
    {
        private Services.TempStorage storage;

        [TestInitialize]
        public void Setup()
        {
            storage = new Services.TempStorage();
        }

        [TestMethod]
        public void TestStoringAndRetrieving()
        {
            // arrange
            double bodyTempCels = 36.6,
                bodyTempFarenh = 98.0;
            
            // act
            storage.AddCelsius(bodyTempCels);
            storage.AddFarenheit(bodyTempFarenh);

            var result = storage.GetPairs();

            //assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TempPair>));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestStoringCelsOnly()
        {
            // arrange
            double bodyTempCels = 36.6;

            // act
            storage.AddCelsius(bodyTempCels);

            var result = storage.GetPairs();

            //assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestStoringFarenhOnly()
        {
            // arrange
            double bodyTempFarenh = 36.6;

            // act
            storage.AddFarenheit(bodyTempFarenh);

            var result = storage.GetPairs();

            //assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
