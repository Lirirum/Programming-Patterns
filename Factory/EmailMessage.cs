using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class EmailMessage : IMessage
    {
        public EmailMessage()
        {
            Console.WriteLine("EmailMessage instance created.");
        }

        public void Send(string sender, string subject, string message)
        {
            Console.WriteLine($"Sending an Email message from {sender} to {subject}: {message}");

        }
    }
}
