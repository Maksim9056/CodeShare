using CodeShare_Library.Date;
using CodeShare_Library.Models;
using Microsoft.Identity.Client;

namespace CodeShareUsers.Service
{
    public class ManagementUser
    {

        private static ManagementUser _instance;

        private CodeShareDB _CodeShareDB;
        private ManagementUser(CodeShareDB codeShareDB )
        {
            _CodeShareDB = codeShareDB;
        }

      
        public void Registration(Users user )
        {

        }

    }
}
