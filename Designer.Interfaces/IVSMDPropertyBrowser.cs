namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDPropertyBrowser
    {
        uint WindowGlyphResourceID { get; }

        IVSMDPropertyGrid CreatePropertyGrid();

        void Refresh();
    }
}
