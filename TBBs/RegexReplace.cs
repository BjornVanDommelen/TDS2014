using System.Text.RegularExpressions;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBs
{
    //The TcmTemplateParameterSchema below allows us to specify a parameter schema from a resource stream.
    //To create it we have a file 'RegexReplace.xsd' in the project folder 'ParameterSchemas' of the project
    //  with the root namespace 'Hinttech.Tridion.DevSummit.Unittesting.TBBs' which should be our current project.
    //Note that the name including root namespace must match exactly and case sensitively and that the resource
    //  in question must have its build action set to 'embedded resource'.
    [TcmTemplateParameterSchema("resource:Hinttech.Tridion.DevSummit.Unittesting.TBBs.ParameterSchemas.RegexReplace.xsd")]
    //The TcmTemplateTitle below will be the name of the csharp fragment TBB that the TcmAssemblyUploader automatically
    //  creates.
    [TcmTemplateTitle("DLL RegexReplace")]
    public class RegexReplace : ITemplate
    {
        #region Implementation of ITemplate
        public void Transform(Engine engine, Package package)
        {
            //Fetch package variables and template paramaters
            string output = package.GetValue(Package.OutputName);
            string pattern = package.GetValue("tp_find");
            string regexOptions = package.GetValue("tp_regexoptions") ?? string.Empty;
            string replace = package.GetValue("tp_replace") ?? string.Empty;

            //Create regex options enum variable
            RegexOptions options = RegexOptions.None;
            if (regexOptions.Contains("i")) { options |= RegexOptions.IgnoreCase; }
            if (regexOptions.Contains("s")) { options |= RegexOptions.Singleline; }
            if (regexOptions.Contains("m")) { options |= RegexOptions.Multiline; }
            if (regexOptions.Contains("r")) { options |= RegexOptions.RightToLeft; }

            //Create regex and perform replace on output
            Regex regex = new Regex(pattern, options);
            output = regex.Replace(output, replace);

            //Update output package variable
            package.GetByName(Package.OutputName).SetAsString(output);
        }
        #endregion
    }
}
