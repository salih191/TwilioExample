using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;

namespace NetFrameworkTwilio.Controllers
{
    public class PhoneController : TwilioController
    {

        public void SendMessage(string message, string number)
        {
            const string accountSid = "TWILIO_ACCOUNT_SID";
            const string authToken = "TWILIO_AUTH_TOKEN";
            TwilioClient.Init(accountSid, authToken);
            var m = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                to: new Twilio.Types.PhoneNumber("whatsapp:" + number)
            );
        }
        public TwiMLResult IncomingSms()
        {
            var body = Request.Form["Body"];
            var to = Request.Form["To"];
            var from = Request.Form["From"];

            var messagingResponse = new MessagingResponse().Message(body);

            return TwiML(messagingResponse);
        }

    }
}