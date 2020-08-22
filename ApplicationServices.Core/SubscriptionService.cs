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
        private readonly ISubsciptionRepository _subsciptionRepository;

        public SubscriptionService(IEmailService emailService, ISubsciptionRepository subsciptionRepository)
        {
            _emailService = emailService;
            _subsciptionRepository = subsciptionRepository;
        }


        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email);
            var isCreated = await _subsciptionRepository.Create(subscription);
            if (!isCreated) return false;
            var email = new ConfirmSubscriptionEmail(request.Email, "newsletterx@mail.net", subscription.VerificationCode);
            var isSent = await _emailService.Send(email);
            return isSent;
        }

        public async Task<bool> Verity(Subscription verificationRequest)
        {
            var subscription = await _subsciptionRepository.ReadByEmail(verificationRequest.Email);
            if (subscription == null || verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }
            subscription.IsVerified = true;
            var hasUpdated = await _subsciptionRepository.Update(subscription);
            return hasUpdated;
        }
    }
}
