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
            var auth = new AuthClient(new Uri("https://intern.dev.bekk.no/autentiseringservice/"), "66bfb7be-8eac-4bbd-b070-89dd62f58a0e", "5f15a688-3f9f-4914-84c7-7b2eab59365d");
            var eClient = new EmployeeClient(auth);
            var x = eClient.GetAll();
        }
    }
}
