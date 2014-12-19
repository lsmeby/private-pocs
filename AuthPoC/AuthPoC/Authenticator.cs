using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bekk.Client.AppAuth;
using Bekk.Client.Employees;

namespace AuthPoC
{
    public class Authenticator
    {
        public void Authenticate()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var auth = new AuthClient(new Uri("https://intern.dev.bekk.no/autentiseringservice/"), "0", "0");
            var eClient = new EmployeeClient(auth);
            var x = eClient.GetAll();
        }
    }
}
