using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SMSMessage : IMessage
    {
        public SMSMessage()
        {
            Console.WriteLine("SMSMessage instance created.");
        }
        public void Send(string sender, string subject, string message)
        {
            Console.WriteLine($"Sending an SMS message from {sender} to {subject}: {message}");
        }
    }
}
