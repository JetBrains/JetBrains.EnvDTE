using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsGradient
    {
        int DrawGradient(IntPtr hwnd, IntPtr hdc, object[] gradientRect, object[] sliceRect);
        int GetGradientVector(int cVector, uint[] rgVector);
    }
}
