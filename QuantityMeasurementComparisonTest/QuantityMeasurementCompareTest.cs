// <copyright file="QuantityMeasurementCompareTest.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace QuantityMeasurementConvertTest
{
    using BusinessLayer.Interface;
    using BusinessLayer.Services;
    using CommanLayer;
    using CommanLayer.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using QuantityMeasurementApi.Controllers;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Services;
    using System;
    using Xunit;

    /// <summary>
    /// Define Class
    /// </summary>
    public class QuantityMeasurementCompareTest
    {
        /// <summary>
        /// Define QuantityMeasurementController instance
        /// </summary>
        private QuantityMeasurementController quantityMeasurementController;

        /// <summary>
        /// Define QuantityMeasurementInterfaceBusiness Instance
        /// </summary>
        private QuantityMeasurementInterfaceBusiness quantityMeasurementInterfaceBusiness;

        /// <summary>
        /// Define QuantityMeasurementInterfaceRepository Instance
        /// </summary>
        private QuantityMeasurementInterfaceRepository quantityMeasurementRepository;

        /// <summary>
        /// Define Temperary Database read Instance
        /// </summary>
        public static DbContextOptions<ApplicationDbContext> Comparisons { get; }

        /// <summary>
        /// Define Database variable
        /// </summary>
        public static string sqlConnectionString = "Data Source=DESKTOP-OF8D1IH;Initial Catalog=QuantityMeasurementDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Define static Function
        /// </summary>
        static QuantityMeasurementCompareTest()
        {
            Comparisons = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        /// <summary>
        /// Define Constructor
        /// </summary>
        public QuantityMeasurementCompareTest()
        {

            var dbContext = new ApplicationDbContext(Comparisons);
            this.quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            this.quantityMeasurementInterfaceBusiness = new QuantityMeasurementBusiness(this.quantityMeasurementRepository);
            this.quantityMeasurementController = new QuantityMeasurementController(this.quantityMeasurementInterfaceBusiness);

        }

        /// <summary>
        /// Test Case of Given 2 Feet To Inch And 24 Inch When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given2FeetToInchAnd24Inch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "FeetToInch",
                    FirstValue = 2,
                    SecondValueUnit = "Inch",
                    SecondValue = 24
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 1 Yard To Inch And 2 Feet To Inch When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given1YardToInchAnd2FeetToInch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "YardToInch",
                    FirstValue = 1,
                    SecondValueUnit = "FeetToInch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 1 Yard To Inch And 36 Inch When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given1YardToInchAnd36Inch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "YardToInch",
                    FirstValue = 1,
                    SecondValueUnit = "Inch",
                    SecondValue = 36
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 14 Inch And 2 Feet To Inch When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given14InchAnd2FeetToInch_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "Inch",
                    FirstValue = 14,
                    SecondValueUnit = "FeetToInch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 5 Centimeter To Inch Value And 2 Inch Value When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given5CentimeterToInchValueAnd2InchValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = "CentimeterToInchValue",
                    FirstValue = 5,
                    SecondValueUnit = "Inch",
                    SecondValue = 2
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null And 2 Inch Value When Compared Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenNullAnd2InchValue_WhenCompared_ReturnsBadResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "length",
                    FirstValueUnit = null,
                    FirstValue = 5,
                    SecondValueUnit = "Inch",
                    SecondValue = 2
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 1 Gallon To Litre Value And 3 point 78 Litre Value When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given1GallonToLitreValueAnd3point78LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "GallonToLitre",
                    FirstValue = 1,
                    SecondValueUnit = "Litre",
                    SecondValue = 3.78
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 100 MiliLitre To Litre Value And 10 Litre Value When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given100MiliLitreToLitreValueAnd10LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "MiliLitreToLitre",
                    FirstValue = 10000,
                    SecondValueUnit = "Litre",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 10 Litre Value And 10 Litre Value When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given10LitreValueAnd10LitreValue_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = "Litre",
                    FirstValue = 10,
                    SecondValueUnit = "Litre",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null Value And 3 point 78 Litre Value When Compared Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenNullValueAnd3point78LitreValue_WhenCompared_ReturnsBadResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "volume",
                    FirstValueUnit = null,
                    FirstValue = 1,
                    SecondValueUnit = "Litre",
                    SecondValue = 3.78
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 1000 Grams To Kilogram Value And 1 KiloGram When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given1000GramsToKilogramValueAnd1KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "GramsToKilogram",
                    FirstValue = 1000,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 1 Tonne To Kilograms Value And 100 KiloGram When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given1TonneToKilogramsValueAnd100KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "TonneToKilograms",
                    FirstValue = 1,
                    SecondValueUnit = "kilogram",
                    SecondValue = 100
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 10 kilogram Value And 10 KiloGram When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given10kilogramValueAnd10KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = "kilogram",
                    FirstValue = 10,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null And 10 KiloGram When Compared Returns Result
        /// </summary>
        [Fact]
        public void GivenNullAnd10KiloGram_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "weight",
                    FirstValueUnit = null,
                    FirstValue = 10,
                    SecondValueUnit = "kilogram",
                    SecondValue = 10
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 22 Fahrenheit To Celsius And 10 Celsius When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given22FahrenheitToCelsiusAnd10Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = "FahrenheitToCelsius",
                    FirstValue = 22,
                    SecondValueUnit = "Celsius",
                    SecondValue = 10
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given 150 Celsius And 150 Celsius When Compared Returns Result
        /// </summary>
        [Fact]
        public void Given150CelsiusAnd150Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = "Celsius",
                    FirstValue = 150,
                    SecondValueUnit = "Celsius",
                    SecondValue = 150
                };
                var okResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null And 150 Celsius When Compared Returns Result
        /// </summary>
        [Fact]
        public void GivenNullAnd150Celsius_WhenCompared_ReturnsResult()
        {
            try
            {
                Compare result = new Compare
                {
                    MeasurementType = "temperature",
                    FirstValueUnit = null,
                    FirstValue = 150,
                    SecondValueUnit = "Celsius",
                    SecondValue = 150
                };
                var badResult = quantityMeasurementController.CompareAndAdd(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Test Case When get Specific Record Returns Result
        /// </summary>
        [Fact]
        public void GivenTestCase_WhengetSpecificRecord_ReturnsResult()
        {
            try
            {
                
                var badResult = quantityMeasurementController.GetComparisonById(265);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Test Case When get All Record Returns Result
        /// </summary>
        [Fact]
        public void GivenTestCase_WhengetAllRecord_ReturnsResult()
        {
            try
            {

                var badResult = quantityMeasurementController.GetAllComparison();
                Assert.IsType<OkObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
