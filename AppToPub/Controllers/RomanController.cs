using AbbTools.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbbTools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanController : ControllerBase
    {
        public DigitConverter digitConverter { get; set; }
        
        public RomanController ()
        {
            digitConverter = new DigitConverter();
        }

        

        [HttpGet]
        public string Index()
        {
            string result = string.Empty;
            result = digitConverter.ConvertRomanToInteger("IXLMVVII").ToString();

            return result;
        }
        
        [HttpPost]
        public IActionResult ConvertRomanToArabic(string income)
        {
            if (income == null || income.Length == 0) return BadRequest("Nothing to convert");
            
            
            income = income.ToUpperInvariant();
            var result = digitConverter.ConvertRomanToInteger(income).ToString();
            if(result == "Error") return BadRequest(digitConverter.ErrorConvert);
            return Ok(result);
        }


    }
}
