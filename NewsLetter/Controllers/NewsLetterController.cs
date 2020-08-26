using System.Threading.Tasks;
using ApplicationServices.Core;
using DomainModel.Core;
using Microsoft.AspNetCore.Mvc;
using SubscriptionViewModel=NewsLetter.ViewModel.Subscription;

namespace NewsLetter.Controllers
{
    [Route("api/newsletter")]
    [ApiController]
    public class NewsLetterController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public NewsLetterController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(SubscriptionViewModel subscriptionInput)
        {
            var subscription = new Subscription { Name = subscriptionInput.Name , Email = subscriptionInput.Email };
            return await _subscriptionService.Subscribe(subscription);
        }

        //Lage en get her
    }
}
