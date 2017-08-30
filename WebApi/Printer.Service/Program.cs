using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourt.ScanListener
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:1339/";

            using (WebApp.Start<Startup1>(url: baseAddress))
            {
                System.Threading.Thread.Sleep(-1);
            }
        }
    }
}
