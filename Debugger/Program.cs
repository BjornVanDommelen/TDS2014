using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hinttech.Tridion.DevSummit.Unittesting.TBBs;
using Hinttech.Tridion.DevSummit.Unittesting.TestHarness;
using Tridion.ContentManager;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            ITemplate tbb = new RegexReplace();
            Session session = new Session();
            Console.WriteLine(session.GetObject("tcm:4-847").Title);
            using (UnittestingTemplatingRenderer engine = new UnittestingTemplatingRenderer("tcm:4-847", "tcm:4-64-32"))
            {
                Package package = new Package(engine);
                package.PushItem(Package.OutputName, package.CreateStringItem(ContentType.Text, "Tridion Developer Summit 2013"));
                package.PushItem("tp_find", package.CreateStringItem(ContentType.Text, "2013"));
                package.PushItem("tp_replace", package.CreateStringItem(ContentType.Text, "2014"));
                tbb.Transform(engine, package);
                string output = package.GetValue(Package.OutputName);
            }
            Console.ReadLine();
        }
    }
}
