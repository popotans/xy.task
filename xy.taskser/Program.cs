﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace xy.taskser
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<BootService>(s =>
                {
                    s.ConstructUsing(name => new BootService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                    //  s.WhenPaused(tc => tc.Pause());
                });
                x.RunAsLocalSystem();

                x.SetDescription("xy.taskser");
                x.SetDisplayName("xy.taskser");
                x.SetServiceName("xy.taskser");
            });
        }
    }
}
