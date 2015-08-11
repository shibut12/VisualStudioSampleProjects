using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager
{
    public class EmailLibrary : IEmailLibrary
    {
        public bool sendEmail(string from, string to, string subject, string body)
        {
            //prepare email
            return true;
        }
    }
}
