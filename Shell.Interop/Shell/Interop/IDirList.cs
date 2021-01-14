namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IDirList
    {
        int get_HWND(out int phwnd);

        int get_Description(out string pbstrDescription);

        int put_Description(string bstrDescription);

        int get_Title(out string pbstrTitle);

        int put_Title(string bstrTitle);

        int put_ShowTitle(bool bShow);

        int put_ShowCheck(bool bShow);

        int get_Count(out int nItems);

        int index(int nItem, out string pbstrItem);

        int Add(string bstrItem);

        int Reset();
    }
}
