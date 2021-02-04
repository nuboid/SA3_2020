using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ARCH.InvoiceService;
using ARCH.Microservice001.WebAPI.Controllers.IOCDemo;
using ARCH.Repositories.Dapper.Invoice;
using Microsoft.AspNetCore.Authorization;

namespace ARCH.Microservice001.WebAPI.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        

        private readonly Functionality1 _functionality1;
        private readonly Class1 _class1;
        private readonly IdempotencyChecker _idempotencyChecker;

        public InvoiceController(
            Functionality1 functionality1,
            Class1 class1,
            Class2 class2,
            Class3 class3,
            IdempotencyChecker idempotencyChecker
        )
        {
            _functionality1 = functionality1;
            _class1 = class1;
            _idempotencyChecker = idempotencyChecker;
        }


        //[HttpPost]
        //public SomeDTO CreateInvoiceForCustomer2([FromQuery] string customerId, [FromBody] SomeDTO request)
        //{
          
        //    return new SomeDTO();


        //}

        [HttpPost]
        public IActionResult CreateInvoiceForCustomer([FromQuery] string customerId, [FromBody] List<InvoiceLineDto> invoiceLines)
        {
            try
            {
                _class1.DoSomething();
                _functionality1.CreateInvoiceForCustomer(customerId, invoiceLines);
                
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            
        }
        
    }
}
