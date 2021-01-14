using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsEnhancedDataTip
    {
        int Show(IntPtr hwndOwner, object[] pptTopLeft, object[] pHotRect);

        int SetExpression(string bstrExpression);

        int GetBaseWindowHandle(out IntPtr phwnd);

        int IsErrorTip(out int pbIsError);

        int IsOpen(out int pbIsOpen);
    }
}
