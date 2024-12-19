using Microsoft.AspNetCore.Mvc;
using Stripe;


namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("create-checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] string id)
        {
            var options1 = new PaymentIntentCreateOptions
            {
                Amount = (long) 1000,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" },
                Metadata = new Dictionary<string, string>
{
      { "OrderId", 123.ToString()},  // Add any relevant metadata
    { "CustomerEmail", "hager@mail.com" }
}
            };
            var service1 = new PaymentIntentService();
            PaymentIntent paymentIntent = await service1.CreateAsync(options1);
            return Ok(new { clientsecret = paymentIntent.ClientSecret });
        }

[HttpGet("list-payments")]
public async Task<IActionResult> ListPayments()
        {
            try
            {
                var service = new PaymentIntentService();
                var options = new PaymentIntentListOptions
                {
                    Limit = 10,  // Adjust this limit as necessary
                };

                var paymentIntents = await service.ListAsync(options);

                // Check if there are any payment intents
                if (paymentIntents.Data.Count == 0)
                {
                    return Ok(new { message = "No payments found." });
                }

                return Ok(paymentIntents);
            }
            catch (StripeException e)
            {
                return StatusCode(500, new { error = e.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}