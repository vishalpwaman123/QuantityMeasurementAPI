using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace QuantityMeasurementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityMeasurementController : ControllerBase
    {
        private QuantityMeasurementInterfaceBusiness quantityMeasurementBusiness;


        public QuantityMeasurementController(QuantityMeasurementInterfaceBusiness quantityMeasurementBusiness)
        {
            this.quantityMeasurementBusiness = quantityMeasurementBusiness;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] Quantity quantity)
        {
            try
            {
                var result = quantityMeasurementBusiness.Convert(quantity);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Added Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Add Data";
                    return this.BadRequest(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quantity>> GetAllQuantity()
        {
            try
            {
                var result = quantityMeasurementBusiness.GetAllQuantity();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data is Found Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Sorry, Not able to Found Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetQuantityById(int Id)
        {
            try
            {
                var result = quantityMeasurementBusiness.GetQuantityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Found Successfully";
                    return this.Ok(new { success, message, Data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Data Not Found";
                    return this.Ok(new { success, message, Data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteQuntityById(int Id)
        {
            try
            {
                var result = quantityMeasurementBusiness.DeleteQuntityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Deleted Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Delete Data";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpPost]
        [Route("compare")]
        public IActionResult CompareAndAdd([FromBody] Compare compare)
        {
            try
            {
                var result = quantityMeasurementBusiness.CompareAndAdd(compare);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Added Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Failed To Add Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpGet]
        [Route("compare")]
        public ActionResult<IEnumerable<Quantity>> GetAllComparison()
        {
            try
            {
                var result = quantityMeasurementBusiness.GetAllComparison();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data Read Successfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Unable To Read Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

    }
}
    