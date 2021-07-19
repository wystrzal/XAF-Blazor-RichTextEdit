using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Blazor_RichTextEdit.Module.Blazor.Editors.Adapters;
using Blazor_RichTextEdit.Module.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;

namespace Blazor_RichTextEdit.Module.Blazor.Editors
{
    [PropertyEditor(typeof(string), "RichTextPropertyEditor", false)]
    public class RichTextPropertyEditor : BlazorPropertyEditorBase
    {
        public RichTextPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new RichTextEditorComponentAdapter(new RichTextEditorComponentModel());
    }
}