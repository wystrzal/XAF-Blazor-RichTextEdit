using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_RichTextEdit.Module.BusinessObjects
{
    [NavigationItem("Default")]
    [DefaultClassOptions]
    [DefaultProperty(nameof(Title))]
    public class RichEdit : XPObject
    {
        public RichEdit(Session session) : base(session)
        { }

        string title;
        string body;

        
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        public string Body
        {
            get => body;
            set => SetPropertyValue(nameof(Body), ref body, value);
        }
    }
}
