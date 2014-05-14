using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBs
{
    /// <summary>
    /// Finds TCMURI in output package variable and replaces it with the item's title
    /// </summary>
    [TcmTemplateTitle("DLL ReplaceTcmuriWithTitle")]
    public class ReplaceTcmuriWithTitle : ITemplate
    {
        #region Implementation of ITemplate
        public void Transform(Engine engine, Package package)
        {
            //Fetch output package variable
            string output = package.GetValue(Package.OutputName);

            //Perform regex match on output
            Regex regex = new Regex("tcm:\\d+\\-\\d+(?:\\-\\d+)?");
            foreach (Match match in regex.Matches(output))
            {
                //Find title of item
                string tcmuri = match.Value;
                string title = engine.GetSession().GetObject(tcmuri).Title;
                //Replace tcmuri with title in output
                output = output.Replace(tcmuri, title);
            }

            //Update output package variable
            package.GetByName(Package.OutputName).SetAsString(output);
        }
        #endregion
    }
}
