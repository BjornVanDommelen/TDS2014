using Hinttech.Tridion.DevSummit.Unittesting.TBBs;
using Hinttech.Tridion.DevSummit.Unittesting.TestHarness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.ContentManager.Templating;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBTests
{
    [TestClass]
    public class ExtractDataTest : TBBTestBase
    {
        public ExtractDataTest()
        {
            this.tbb = new ExtractData();
        }

        [TestMethod]
        public void TestDataLength()
        {
            this.Init();
            //Add Component variable to the package (same as resolved item)
            package.AddComponent(Package.ComponentName, "tcm:4-847");
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.AreEqual(8995, output.Length);
        }

        [TestMethod]
        public void TestDataNotEncoded()
        {
            this.Init();
            //Add Component variable to the package (same as resolved item)
            package.AddComponent(Package.ComponentName, "tcm:4-847");
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.IsFalse(output.Contains("&lt;") || output.Contains("&gt;") || output.Contains("&amp;"));
        }
    }
}
