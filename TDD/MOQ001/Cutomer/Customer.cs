using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myEmailLibrary;

namespace Cutomer
{
    public class Customer
    {
        private IMyEmail _emailObject;
        public Customer(IMyEmail emailObject)
        {
            _emailObject = emailObject;
        }
        public bool AddCutomer()
        {
            bool isSentMail = _emailObject.sendEmail();
            if (isSentMail)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
