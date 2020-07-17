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

namespace QuentityMeasurementTest
{
    public class QuentityMeasurementConvertTest
    {
        QuantityMeasurementController quantityMeasurementController;
        QuantityMeasurementInterfaceBusiness quantityMeasurementInterfaceBusiness;
        QuantityMeasurementInterfaceRepository quantityMeasurementRepository;

        public static DbContextOptions<ApplicationDbContext> Quantities { get; }

        public static string sqlConnectionString = "Data Source=DESKTOP-OF8D1IH;Initial Catalog=QuantityMeasurementDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static QuentityMeasurementConvertTest()
        {
            Quantities = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(sqlConnectionString).Options;
        }

        public QuentityMeasurementConvertTest()
        {

            var dbContext = new ApplicationDbContext(Quantities);
            this.quantityMeasurementRepository = new QuantityMeasurementRepository(dbContext);
            this.quantityMeasurementInterfaceBusiness = new QuantityMeasurementBusiness(this.quantityMeasurementRepository);
            this.quantityMeasurementController = new QuantityMeasurementController(this.quantityMeasurementInterfaceBusiness);

        }


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

        /*[Fact]
        public void GivenTestUsed_WhenGetAllReCord_ReturnsResult()
        {

            try
            {
                var Result = quantityMeasurementController.GetAllQuantity();
                
                Assert.IsType<OkNegotiatedContentResult<object>>(Result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

    }
}
