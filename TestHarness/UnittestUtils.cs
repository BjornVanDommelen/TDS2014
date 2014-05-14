using Tridion.ContentManager;
using Tridion.ContentManager.Templating;

namespace Hinttech.Tridion.DevSummit.Unittesting.TestHarness
{
    /// <summary>
    /// Static utility class for extension methods
    /// </summary>
    public static class UnittestUtils
    {
        #region Package extension methods
        public static void AddString(this Package package, string name, string value)
        {
            package.PushItem(name, package.CreateStringItem(ContentType.Text, value));
        }

        public static void AddComponent(this Package package, string name, string tcmuri)
        {
            package.PushItem(name, package.CreateTridionItem(ContentType.Component, new TcmUri(tcmuri)));
        }
        #endregion
    }
}
