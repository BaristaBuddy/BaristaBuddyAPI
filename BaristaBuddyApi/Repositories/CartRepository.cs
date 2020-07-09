using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class CartRepository
    {
         public static async Task<dynamic> CreatePayement(string cardnumber, int month, int year, int value, string cvc)
        {
            StripeConfiguration.ApiKey = "sk_test_51H2knvH2NJeUpvbl9dHq36t8evGWp88N9eCa8pUGBS5J5HSrQ2NNeEpnCc1znVwgKojg8wSksQE5Ffz9zEzvkwNE00OSiQdQPB";
            

            var optionsToken = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = cardnumber,
                    ExpMonth = month,
                    ExpYear = year,
                    Cvc = cvc
                }
            };

            var servicetoken = new TokenService();
            Token stripetoken = await servicetoken.CreateAsync(optionsToken);
            // `source` is obtained with Stripe.js; see https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token
            var options = new ChargeCreateOptions
            {

                Amount = value,
                Currency = "usd",
                Source = stripetoken.Id,
                Description = "My First Test Charge (created for API docs)",
            };
            var service = new ChargeService();
            Charge charge = await service.CreateAsync(options);

            if (charge.Paid)
            {
                return "success";
            }
            else
            {
                return "failed";
            }
        }
    }
}
