using System;
using TempConverter.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TempConverter.Tests
{
    [TestClass]
    public class TempConverterTest
    {
        private Services.TempConverter converter;

        [TestInitialize]
        public void Setup()
        {
            converter = new Services.TempConverter();
        }

        [TestMethod]
        public void TestCelsiusToFarenheitConversion()
        {
            // arrange
            var bodyTemp = 36.6;

            // act
            var result = converter.Convert(bodyTemp, ConversionType.CelsiusToFarenheit);

            //assert
            Assert.AreEqual(97.88, result);
        }

        [TestMethod]
        public void TestFarenheitToCelsiusConversion()
        {
            // arrange
            var bodyTemp = 97.88;

            // act
            var result = converter.Convert(bodyTemp, ConversionType.FarenheitToCelsius);

            //assert
            Assert.AreEqual(36.6, result);
        }

        [TestMethod]
        public void TestFarenheitRoundConversion()
        {
            // arrange
            var bodyTemp = 97.88;

            // act
            var result = converter.Convert(converter.Convert(bodyTemp, ConversionType.FarenheitToCelsius), ConversionType.CelsiusToFarenheit);

            //assert
            Assert.AreEqual(bodyTemp, result);
        }

        [TestMethod]
        public void TestCelsiusRoundConversion()
        {
            // arrange
            var bodyTemp = 36.6;

            // act
            var result = converter.Convert(converter.Convert(bodyTemp, ConversionType.CelsiusToFarenheit), ConversionType.FarenheitToCelsius);

            //assert
            Assert.AreEqual(bodyTemp, result);
        }
    }
}
