// <copyright file="UnitTest1.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace QuentityMeasurementTestProject
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
    public class UnitTest1
    {
        /// <summary>
        /// Define Quantity Measurement Controller Instance
        /// </summary>
        private QuantityMeasurementController quantityMeasurementController;

        /// <summary>
        /// Define Quantity Measurement Interface Business Instance
        /// </summary>
        private QuantityMeasurementInterfaceBusiness quantityMeasurementInterfaceBusiness;

        /// <summary>
        /// Define QuantityMeasurementInterfaceRepository Instance
        /// </summary>
        private QuantityMeasurementInterfaceRepository quantityMeasurementRepository;

        /// <summary>
        /// Define Database Instance for read value
        /// </summary>
        public static DbContextOptions<ApplicationDbContext> Quantities { get; }

        /// <summary>
        /// Define sql connection variable
        /// </summary>
        public static string sqlConnectionString = "Data Source=DESKTOP-OF8D1IH;Initial Catalog=QuantityMeasurementDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Define static method
        /// </summary>
        static UnitTest1()
        {
            Quantities = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        /// <summary>
        /// Define constructor
        /// </summary>
        public UnitTest1()
        {

            var dbContext = new ApplicationDbContext(Quantities);
            this.quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            this.quantityMeasurementInterfaceBusiness = new QuantityMeasurementBusiness(this.quantityMeasurementRepository);
            this.quantityMeasurementController = new QuantityMeasurementController(this.quantityMeasurementInterfaceBusiness);

        }

        /// <summary>
        /// Test Case of Given Feet To Inch When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenFeetToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {

            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToInch",
                    Value = 5
                };

                var Result = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Yard To Inch When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenYardToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "YardToInch",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Centimeter To Inch When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenCentimeterToInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "CentimeterToInch",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Inch When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenInch_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "Inch",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Grams To Kilogram When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenGramsToKilogram_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "GramsToKilogram",
                    Value = 5000
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Tonne To Kilograms When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenTonneToKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "TonneToKilograms",
                    Value = 0.5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Kilograms When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenKilograms_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "Kilograms",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Gallon To Litre When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenGallonToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "GallonToLitre",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Mili Litre To Litre When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenMiliLitreToLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "MiliLitreToLitre",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Litre When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenLitre_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "Litre",
                    Value = 5
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Temperature When Convert And Add Method Used Returns Result
        /// </summary>
        [Fact]
        public void GivenTemperature_WhenConvertAndAddMethodUsed_ReturnsResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 500
                };
                var okResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null When Converted Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenNull_WhenConverted_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = null,
                    ConversionType = "GramsToKilogram",
                    Value = 500
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Null When Conversion Type Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenNull_WhenConversionType_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = null,
                    Value = 500
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Empty When Converted Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenEmpty_WhenConverted_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "",
                    ConversionType = "",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given length When Converted Into Weight Returns Bad Result
        /// </summary>
        [Fact]
        public void Givenlength_WhenConvertedIntoWeight_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "GramsToKilogram",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given length When Converted Into Volume Returns Bad Result
        /// </summary>
        [Fact]
        public void Givenlength_WhenConvertedIntoVolume_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "GallonToLitre",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given length When Converted Into Temperature Returns Bad Result
        /// </summary>
        [Fact]
        public void Givenlength_WhenConvertedIntoTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Weight When Converted Into Length Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenWeight_WhenConvertedIntoLength_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "FeetToInch",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Weight When Converted To Volume Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenWeight_WhenConvertedToVolume_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "GallonToLitre",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Weight When Converted Temperature Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenWeight_WhenConvertedTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Volume When Converted Length Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenVolume_WhenConvertedLength_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "FeetToInch",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Volume When Convert To Weight Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenVolume_WhenConvertTodWeight_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "GramsToKilogram",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Volume When Convert To Temperature Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenVolume_WhenConvertToTemperature_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "FahrenheitToCelsius",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Temperature When Convert Length Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenTemperature_WhenConvertLength_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "FeetToInch",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Temperature When Converted To Volume Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenTemperature_WhenConvertedToVolume_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "GallonToLitre",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Temperature When Converted To Weight Returns Bad Result
        /// </summary>
        [Fact]
        public void GivenTemperature_WhenConvertedToWeight_ReturnsBadResult()
        {
            try
            {
                Quantity result = new Quantity
                {
                    MeasurementType = "temperature",
                    ConversionType = "Kilogram",
                    Value = 5
                };
                var badResult = quantityMeasurementController.ConvertToUnit(result);
                Assert.IsType<BadRequestObjectResult>(badResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Test Used When Get Specific ReCord Return Result
        /// </summary>
        [Fact]
        public void GivenTestUsed_WhenGetSpecificReCord_ReturnsResult()
        {

            try
            {
                var Result = quantityMeasurementController.GetQuantityById(6);
                
                Assert.IsType<OkObjectResult>(Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Test Case of Given Test Used When Get All ReCord Returns Result
        /// </summary>
        [Fact]
        public void GivenTestUsed_WhenGetAllReCord_ReturnsResult()
        {

            try
            {
                var Result = quantityMeasurementController.GetAllQuantity();
                Assert.IsType<OkObjectResult>(Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /*[Fact]
        public void GivenTestUsed_WhenGetReCordbydId_ReturnsResult()
        {

            try
            {
                int data = quantityMeasurementController.GetQuantityById(6);
                int ExpectationValue = 1; 
                Assert.AreEqual(ExpectationValue, Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/
    }
}
