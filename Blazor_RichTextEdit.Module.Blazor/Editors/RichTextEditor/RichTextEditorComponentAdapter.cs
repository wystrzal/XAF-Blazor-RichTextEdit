using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Blazor_RichTextEdit.Module.Blazor.Components.Models;
using Blazor_RichTextEdit.Module.Blazor.Editors.RichTextEditor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_RichTextEdit.Module.Blazor.Editors.Adapters
{
    public class RichTextEditorComponentAdapter : ComponentAdapterBase
    {
        public RichTextEditorComponentAdapter(RichTextEditorComponentModel componentModel)
        {
            ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            ComponentModel.ValueChanged += ComponentModel_ValueChanged;
        }
        public RichTextEditorComponentModel ComponentModel { get; }
        public override void SetAllowEdit(bool allowEdit)
        {
            ComponentModel.ReadOnly = !allowEdit;
        }
        public override object GetValue()
        {
            if (ComponentModel.Value == null)
            {
                return null;
            }
            using var wordProcessor = new RichEditDocumentServer();
            Document document = wordProcessor.Document;
            document.LoadDocument(ComponentModel.Value);
            return document.HtmlText;
        }
        public override void SetValue(object value)
        {
            if (value == null)
            {
                ComponentModel.Value = null;
                return;
            }

            value = value.ToString().Replace("<br>", "\n");
            using var wordProcessor = new RichEditDocumentServer();
            Document document = wordProcessor.Document;
            document.LoadDocument(Encoding.UTF8.GetBytes(value.ToString()));
            ComponentModel.Value = document.SaveDocument(DocumentFormat.Docm);
        }
        protected override RenderFragment CreateComponent()
        {
            return ComponentModelObserver.Create(ComponentModel, RichTextEditorComponent.Create(ComponentModel));
        }

        private void ComponentModel_ValueChanged(object sender, EventArgs e) => RaiseValueChanged();
        public override void SetAllowNull(bool allowNull) { /* ...*/ }
        public override void SetDisplayFormat(string displayFormat) { /* ...*/ }
        public override void SetEditMask(string editMask) { /* ...*/ }
        public override void SetEditMaskType(EditMaskType editMaskType) { /* ...*/ }
        public override void SetErrorIcon(ImageInfo errorIcon) { /* ...*/ }
        public override void SetErrorMessage(string errorMessage) { /* ...*/ }
        public override void SetIsPassword(bool isPassword) { /* ...*/ }
        public override void SetMaxLength(int maxLength) { /* ...*/ }
        public override void SetNullText(string nullText) { /* ...*/ }
    }
}