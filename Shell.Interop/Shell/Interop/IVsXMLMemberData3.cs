namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsXMLMemberData3
    {
        int SetOptions(uint options);


        int GetSummaryText(out string pbstrSummary);


        int GetParamCount(out int piParams);


        int GetParamTextAt(int iParam, out string pbstrName, out string pbstrText);


        int GetReturnsText(out string pbstrReturns);


        int GetRemarksText(out string pbstrRemarks);


        int GetExceptionCount(out int piExceptions);


        int GetExceptionTextAt(int iException, out string pbstrType, out string pbstrText);


        int GetFilterPriority(out int piFilterPriority);


        int GetCompletionListText(out string pbstrCompletionList);


        int GetCompletionListTextAt(int iParam, out string pbstrCompletionList);


        int GetPermissionSet(out string pbstrPermissionSetXML);


        int GetTypeParamCount(out int piTypeParams);


        int GetTypeParamTextAt(int iTypeParam, out string pbstrName, out string pbstrText);
    }
}
