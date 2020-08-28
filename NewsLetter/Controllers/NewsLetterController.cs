using System;
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
        public async Task<bool> SubscribeToNewsletter(SubscriptionViewModel subscriptionInput)
        {
            var subscription = new Subscription { Name = subscriptionInput.Name , Email = subscriptionInput.Email, VerificationCode = subscriptionInput.VerificationCode};
            return await _subscriptionService.Subscribe(subscription);
        }

        [HttpGet("{Name}")]
        public async Task<SubscriptionViewModel> Read(string name)
        {
            var getUser = await _subscriptionService.GetUser(name);
            return new SubscriptionViewModel(getUser.Name, getUser.Email);
        }


        [HttpPatch]
        public async Task<bool> Update(SubscriptionViewModel subscriptionInput)
        {
            var subscription = new Subscription { Name = subscriptionInput.Name, Email = subscriptionInput.Email, VerificationCode = subscriptionInput.VerificationCode};
            return await _subscriptionService.Verify(subscription);
        }

    }
}
