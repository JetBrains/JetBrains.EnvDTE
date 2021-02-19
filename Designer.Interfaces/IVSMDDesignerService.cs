namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDDesignerService
    {
        string DesignViewAttribute { get; }

        IVSMDDesigner CreateDesigner(
            object pSp,
            object pDesignerLoader);

        IVSMDDesigner CreateDesignerForClass(
            object pSp, string pwszComponentClass);

        object CreateDesignerLoader(string pwszCodeStreamClass);

        string GetDesignerLoaderClassForFile(string pwszFileName);

        void RegisterDesignViewAttribute(
            object pHier,
            int itemid,
            int dwClass,
            string pwszAttributeValue);
    }
}
