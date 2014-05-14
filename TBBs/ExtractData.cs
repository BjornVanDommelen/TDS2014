using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tridion.ContentManager.Templating;
using Tridion.ContentManager.Templating.Assembly;

namespace Hinttech.Tridion.DevSummit.Unittesting.TBBs
{
    [TcmTemplateTitle("DLL ExtractData")]
    public class ExtractData : ITemplate
    {
        #region Implementation of ITemplate
        public void Transform(Engine engine, Package package)
        {
            //Emid the field "data" as output
            package.PushItem(
                Package.OutputName, 
                package.CreateStringItem(
                    ContentType.Text, 
                    package.GetValue("Component.Fields.data")
                )
            );
        }
        #endregion
    }
}
