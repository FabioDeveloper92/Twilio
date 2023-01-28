using TwilioExample.Service;

var twilioAccountSid = "";
var twilioAuthToken = "";
var fromPhone = "";
var serviceId = "";
var toPhoneNumber = "";

var twilioService = new TwilioService(twilioAccountSid, twilioAuthToken, fromPhone, serviceId);
twilioService.SendSimpleMessage(toPhoneNumber, "Test with service");

twilioService.SendVerificationMessage(toPhoneNumber);

var myCode = "123456";
twilioService.CheckVerificationMessage(toPhoneNumber, myCode);
