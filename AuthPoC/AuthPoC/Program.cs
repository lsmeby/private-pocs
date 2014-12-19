using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bekk.Client.AppAuth;
using Bekk.Client.Employees;

namespace AuthPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Authenticator();
            a.Authenticate();

            Console.ReadLine();
        }
    }
}
