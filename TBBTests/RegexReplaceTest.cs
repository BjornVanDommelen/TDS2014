using Hinttech.Tridion.DevSummit.Unittesting.TBBs;
using Hinttech.Tridion.DevSummit.Unittesting.TestHarness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.ContentManager.Templating;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBTests
{
    [TestClass]
    public class RegexReplaceTest : TBBTestBase
    {
        public RegexReplaceTest()
        {
            this.tbb = new RegexReplace();
        }

        [TestMethod]
        public void TestSimpleReplace()
        {
            this.Init();
            package.AddString(Package.OutputName, "Tridion Developer Summit 2013");
            package.AddString("tp_find", "2013");
            package.AddString("tp_replace", "2014");
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.AreEqual("Tridion Developer Summit 2014", output);
        }

        [TestMethod]
        public void TestCaseSensitiveReplace()
        {
            this.Init();
            package.AddString(Package.OutputName, "Tridion Developer Summit 2013");
            package.AddString("tp_find", "developer");
            package.AddString("tp_replace", "partner");
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.AreEqual("Tridion Developer Summit 2013", output);
        }

        [TestMethod]
        public void TestCaseInsensitiveReplace()
        {
            this.Init();
            package.AddString(Package.OutputName, "Tridion Developer Summit 2013");
            package.AddString("tp_find", "developer");
            package.AddString("tp_regexoptions", "i");
            package.AddString("tp_replace", "partner");
            tbb.Transform(engine, package);
            string output = package.GetValue(Package.OutputName);
            Assert.AreEqual("Tridion partner Summit 2013", output);
        }
    }
}
