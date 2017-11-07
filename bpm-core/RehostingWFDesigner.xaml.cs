using System;
using System.Activities.Core.Presentation;
using System.Activities.Presentation;
using System.Activities.Presentation.Metadata;
using System.Activities.Presentation.Toolbox;
using System.Activities.Statements;
using System.ComponentModel;

namespace BpmCore
{
    // Interaction logic for RehostingWFDesigner.xaml  
    public partial class RehostingWFDesigner
    {
        public RehostingWFDesigner()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            // register metadata  
            (new DesignerMetadata()).Register();
            RegisterCustomMetadata();
            // add custom activity to toolbox  
            Toolbox.Categories.Add(new ToolboxCategory("Custom activities"));
            Toolbox.Categories[1].Add(new ToolboxItemWrapper(typeof(SimpleNativeActivity)));

            // create the workflow designer  
            WorkflowDesigner wd = new WorkflowDesigner();
            wd.Load(new Sequence());
            DesignerBorder.Child = wd.View;
            PropertyBorder.Child = wd.PropertyInspectorView;

        }

        void RegisterCustomMetadata()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();
            builder.AddCustomAttributes(typeof(SimpleNativeActivity), new DesignerAttribute(typeof(SimpleNativeDesigner)));
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
