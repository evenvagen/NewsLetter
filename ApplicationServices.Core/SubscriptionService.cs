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
            var subscription = new Subscription(request.Name, request.Email);
            subscription.IsVerified = true;


            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var email = new ConfirmSubscriptionEmail(request.Email, "newsletterx@mail.net", subscription.VerificationCode);
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
    }
}
