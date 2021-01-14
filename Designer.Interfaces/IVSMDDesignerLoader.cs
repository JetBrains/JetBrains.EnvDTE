namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDDesignerLoader
    {
        void Dispose();

        string GetEditorCaption(int status);

        void Initialize(object pSp, object pHier, int itemid, object pDocData);

        void SetBaseEditorCaption(string pwszCaption);
    }
}
