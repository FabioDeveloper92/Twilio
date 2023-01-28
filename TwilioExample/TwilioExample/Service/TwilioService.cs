using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;

namespace TwilioExample.Service
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;
        private readonly string _serviceId;

        public TwilioService(string accountSid, string authToken, string fromPhoneNumber, string serviceId)
        {
            _accountSid = accountSid;
            _authToken = authToken;
            _fromPhoneNumber = fromPhoneNumber;
            _serviceId = serviceId;
            TwilioClient.Init(_accountSid, _authToken);
        }

        public MessageResource SendSimpleMessage(string toPhoneNumber, string body)
        {
            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber(_fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            return message;
        }

        public string SendVerificationMessage(string toPhoneNumber)
        {
            var verification = VerificationResource.Create(
                to: toPhoneNumber,
                channel: "sms",
                pathServiceSid: _serviceId
            );

            return verification.Status;
        }

        public string CheckVerificationMessage(string toPhoneNumber, string code)
        {
            var verificationCheck = VerificationCheckResource.Create(
                to: toPhoneNumber,
                code: code,
                pathServiceSid: _serviceId
            );

            return verificationCheck.Status;
        }
    }
}
