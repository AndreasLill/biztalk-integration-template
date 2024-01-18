using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using System;
using System.ComponentModel;

namespace BizTalk.IntegrationTemplate.PipelineComponents
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("00000000-0000-0000-0000-000000000000")]
    public partial class ExamplePipelineComponent : IBaseComponent, IPersistPropertyBag, Microsoft.BizTalk.Component.Interop.IComponent
    {
        #region Configuration

        public string Name => "ExamplePipelineComponent";

        public string Version => "1.0.0";

        public string Description => "PipelineComponent Description";

        [Description("Property Description")]
        [DisplayName("Example Property")]
        public string ExampleProperty { get; set; }

        public void GetClassID(out Guid classID)
        {
            classID = new Guid("00000000-0000-0000-0000-000000000000");
        }

        public void InitNew()
        {
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            object val = ReadPropertyBag(propertyBag, "ExampleProperty");
            if (val != null) ExampleProperty = val as string;
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            propertyBag.Write("ExampleProperty", ExampleProperty);
        }

        private object ReadPropertyBag(IPropertyBag propertyBag, string propName)
        {
            object val = null;
            try
            {
                propertyBag.Read(propName, out val, 0);
            }
            catch (ArgumentException)
            {
                return val;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message, e);
            }
            return val;
        }

        #endregion

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            throw new NotImplementedException();
        }
    }
}
