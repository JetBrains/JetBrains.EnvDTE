using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsTaskItem3
    {
        int GetTaskProvider(out IVsTaskProvider3 ppProvider);


        int GetTaskName(out string pbstrName);


        int GetColumnValue(
            int iField,
            out uint ptvtType,
            out uint ptvfFlags,
            out object pvarValue,
            out string pbstrAccessibilityName);


        int GetTipText(int iField, out string pbstrTipText);


        int SetColumnValue(int iField, ref object pvarValue);


        int IsDirty(out int pfDirty);


        int GetEnumCount(int iField, out int pnValues);


        int GetEnumValue(
            int iField,
            int iValue,
            out object pvarValue,
            out string pbstrAccessibilityName);


        int OnLinkClicked(int iField, int iLinkIndex);


        int GetNavigationStatusText(out string pbstrText);


        int GetDefaultEditField(out int piField);


        int GetSurrogateProviderGuid(out Guid pguidProvider);
    }
}
