using Gulf_Chatbot_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gulf_Chatbot_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        [HttpGet("ValidateIDIqamaNumber/{id}")]
        public IActionResult ValidateIDIqamaNumber([FromRoute] long id)
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;

            //if (culture == "ar-SA")
            //    return Ok("مرحباً بك 👋");

            //return Ok("Hello 👋");

            if (id == 0)
                return BadRequest(new ChatbotResponse { Message = "Invalid ID Or IqamaNumber" });

            return Ok(new ChatbotResponse { Valid = true });

        }


        [HttpGet("ValidateOtp/{otp}")]
        public IActionResult ValidateOtp([FromRoute] string otp)
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;

            //if (culture == "ar-SA")
            //    return Ok("مرحباً بك 👋");

            //return Ok("Hello 👋");

            if (string.IsNullOrEmpty(otp))
                return BadRequest(new ChatbotResponse { Message = "Invalid otp" });

            return Ok(new ChatbotResponse { Valid = true });

        }

        [HttpGet("ValidatePolicy/{policyNumber}")]
        public IActionResult ValidatePolicy([FromRoute] long policyNumber)
        {
            var culture = Thread.CurrentThread.CurrentCulture.Name;

            if (policyNumber == 0)
                return BadRequest(new ChatbotResponse { Message = "Invalid Policy Number" });

            string ResponseMessage= string.Empty;
            string PaymentUrl = "http://chatbotdev.gulfunion.com.sa:8068";
            if (culture == "ar-SA")
                ResponseMessage = $"تفاصيل الوثيقة : {policyNumber}\n رابط الدفع : {PaymentUrl}";
            else
                ResponseMessage = $"Policy Details : {policyNumber}\n Payment Link : {PaymentUrl}";


            return Ok(new ChatbotResponse { Valid = true ,Message = ResponseMessage});

        }

    }
}
