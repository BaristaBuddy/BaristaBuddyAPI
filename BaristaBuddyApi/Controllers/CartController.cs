
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    public class CartController :Controller
    {
        public  ActionResult Create (string stripeToken )
        {
            StripeConfiguration.ApiKey = "sk_test_51H2knvH2NJeUpvbl9dHq36t8evGWp88N9eCa8pUGBS5J5HSrQ2NNeEpnCc1znVwgKojg8wSksQE5Ffz9zEzvkwNE00OSiQdQPB";

            // `source` is obtained with Stripe.js; see https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "usd",
                Source = stripeToken,
                Description = "My First Test Charge (created for API docs)",
            };
            var service = new ChargeService();
            service.Create(options);

            return View();
        }

        

    }
}
