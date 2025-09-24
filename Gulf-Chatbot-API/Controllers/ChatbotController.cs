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

            //if (culture == "ar-SA")
            //    return Ok("مرحباً بك 👋");

            //return Ok("Hello 👋");

            if (policyNumber == 0)
                return BadRequest(new ChatbotResponse { Message = "Invalid Policy Number" });

            return Ok(new ChatbotResponse { Valid = true });

        }

    }
}
