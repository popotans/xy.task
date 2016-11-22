using CassiniDev;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xy.task
{
    class BootService
    {
        private Server server;
        public BootService()
        {

        }

        public void Start()
        {
            Console.WriteLine("service started");

            int webappport = 6678;
            int.TryParse(ConfigurationManager.AppSettings["webappport"], out webappport);

            string virtialPath = "/";
            string physicalPath = Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".."));
            physicalPath = AppDomain.CurrentDomain.BaseDirectory + "\\WebApp";
            Console.WriteLine("virtialPath=" + virtialPath);
            Console.WriteLine("physicalPath=" + physicalPath);
            server = new Server(webappport, virtialPath, physicalPath,
                System.Net.IPAddress.Parse("0.0.0.0"), "", 0, true, true);

            server.Start();

            Console.WriteLine("Server Started in port=" + webappport + ",virtialPath=" + virtialPath + ",physicalPath=" + physicalPath);
            server.RequestComplete += server_RequestComplete;
        }

        void server_RequestComplete(object sender, RequestEventArgs e)
        {
            Console.WriteLine(e.RequestLog.Url);
        }

        public void Stop()
        {

        }

        public void Pause()
        {

        }
    }
}
