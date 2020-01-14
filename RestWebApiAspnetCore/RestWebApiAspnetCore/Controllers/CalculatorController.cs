using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using RestWebApiAspnetCore.util;

namespace RestWebApiAspnetCore.Controllers
{

  
    [Route("api/[Controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (Utilitario.IsNumeric(firstNumber) && Utilitario.IsNumeric(secondNumber))
            {
                var sum = Utilitario.ConvertToDecimal(firstNumber) + Utilitario.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
     

        // GET api/values/Subtraction/5/5
        [HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (Utilitario.IsNumeric(firstNumber) && Utilitario.IsNumeric(secondNumber))
            {
                var sum = Utilitario.ConvertToDecimal(firstNumber) - Utilitario.ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }
    }
}