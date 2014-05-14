using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Hinttech.Tridion.DevSummit.Unittesting.TestHarness
{
    /// <summary>
    /// Utility base class for TBB tests to simplify engine and package handling
    /// </summary>
    public abstract class TBBTestBase
    {
        /// <summary>
        /// Template building block; needs to be set in constructor of derived class
        /// </summary>
        protected ITemplate tbb { get; set; }
        /// <summary>
        /// Engine object; initialized when Init() is called
        /// </summary>
        protected UnittestingTemplatingRenderer engine { get; set; }
        /// <summary>
        /// Package object; initialized when Init() is called
        /// </summary>
        protected Package package { get; set; }

        /// <summary>
        /// Initializes engine and package with given item and template as context
        /// </summary>
        /// <param name="itemUri">Context item for rendering</param>
        /// <param name="templateUri">Template for rendering</param>
        protected void Init(string itemUri, string templateUri)
        {
            this.engine = new UnittestingTemplatingRenderer(itemUri, templateUri);
            this.package = new Package(engine);
        }

        /// <summary>
        /// Initializes engine and package with don't care item and template as context
        /// </summary>
        protected void Init()
        {
            this.Init("tcm:4-847", "tcm:4-64-32");
        }

        [TestCleanup]
        protected void Cleanup()
        {
            if (this.engine != null) { this.engine.Dispose(); }
        }
    }
}
