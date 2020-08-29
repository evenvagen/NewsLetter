using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Core;
using DomainServices.Core;

namespace ApplicationServices.Core
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubsciptionRepository _subscriptionRepository;

        public SubscriptionService(IEmailService emailService, ISubsciptionRepository subscriptionRepository)
        {
            _emailService = emailService;
            _subscriptionRepository = subscriptionRepository;
        }


        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email, request.VerificationCode);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var url = $"https://localhost:44300/index.html?email={subscription.Email}&code={subscription.VerificationCode}&name={subscription.Name}";
            var text = $"Hello {request.Name}! <a href=\"{url}\">Click here to confirm subscription!";
            var email = new Email(request.Email, "evenvagen@hotmail.com", subscription.VerificationCode, text);
            var isSent = await _emailService.Send(email);
            return isSent;
        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (subscription == null || verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }
            subscription.IsVerified = true;
            var hasUpdated = await _subscriptionRepository.Update(subscription);
            return hasUpdated;
        }

        public async Task<Subscription> GetUser(string name)
        {
            return await _subscriptionRepository.Read(name);
        }



    }
}
