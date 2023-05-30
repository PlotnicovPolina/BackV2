using AutoMapper;
using Azure;
using BackV2.BackV2Exception;
using BackV2.Controllers.Dto;
using BackV2.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;

namespace BackV2.Controllers
{
    [ApiController]
    public class MiddlewareController : Controller
    {
        public MiddlewareController(){}

        [HttpGet("[action]")]
        [SwaggerOperation(
          Summary = "MiddlewareTest",
          OperationId = "midleware.test",
          Tags = new[] { "Middleware" })
        ]
        public async Task<ActionResult<String>> MiddlewareTest()
        {
            /*Debug.WriteLine("After call middleware class");
            try
            {*/
                Debug.WriteLine("(Controller) try body");
                throw new BaseException("BaseExcetion");
            /*}
            catch (Exception ex)
            {
                Debug.WriteLine($"Error (Controller): {ex.Message}");
            }*/
            Debug.WriteLine("Before call middleware class");
            return Ok("success");
        }
    }
}
