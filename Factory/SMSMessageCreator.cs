using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class SMSMessageCreator : MessageCreator
    {
        public override IMessage CreateMessage()
        {
            return new SMSMessage();
        }
    }
}
