using Hinttech.Tridion.DevSummit.Unittesting.TBBs;
using Hinttech.Tridion.DevSummit.Unittesting.TestHarness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.ContentManager.Templating;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBTests
{
    [TestClass]
    public class ReplaceTcmuriWithTitleTest : TBBTestBase
    {
        public ReplaceTcmuriWithTitleTest()
        {
            this.tbb = new ReplaceTcmuriWithTitle();
        }

        [TestMethod]
        public void TestFromComponentField()
        {
            this.Init("tcm:24-752", "tcm:24-64-32");
            //Add Component variable to the package (same as resolved item)
            package.AddComponent(Package.ComponentName, "tcm:24-752");
            //Add output package variable from component field
            package.AddString(Package.OutputName, package.GetValue("Component.Fields.introduction"));
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.IsFalse(output.Contains("xlink:href=\"tcm:"));
        }
    }
}
