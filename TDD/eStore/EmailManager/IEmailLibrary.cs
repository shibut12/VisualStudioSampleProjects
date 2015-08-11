using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager
{
    public interface IEmailLibrary
    {
        bool sendEmail(string from, string to, string subject, string body);
    }
}
