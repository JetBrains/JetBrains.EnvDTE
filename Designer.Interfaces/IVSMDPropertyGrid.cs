namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDPropertyGrid
    {
        bool CommandsVisible { get; }

        int Handle { get; }

        _PROPERTYGRIDSORT GridSort { get; set; }

        string SelectedPropertyName { get; }

        void Dispose();

        object GetOption(_PROPERTYGRIDOPTION option);

        void Refresh();

        void SetOption(_PROPERTYGRIDOPTION option, object vtOption);

        void SetSelectedObjects(int cObjects, int ppUnk);
    }
}
