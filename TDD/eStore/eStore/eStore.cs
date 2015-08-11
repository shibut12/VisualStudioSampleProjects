using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager;

namespace eStore
{
    public class eStore
    {
        private readonly IEmailLibrary _IEmailLibrary;

        public eStore(IEmailLibrary emailLib)
        {
            _IEmailLibrary = emailLib;
        }
        public virtual bool addUser(Customer customer)
        {
            //notify user
            bool isNotified =_IEmailLibrary.sendEmail("test frome", "test to", "test subject", "test body");

            if (isNotified)
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
