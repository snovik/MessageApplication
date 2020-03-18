using System;

namespace MessageApplication.Web.Message
{
    public class SmsMessage : IMessage
    {
        public void Send(string message)
        {
            Console.WriteLine("Sms send");
        }
    }
}
