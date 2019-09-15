using System;

namespace EnvDTE
{
    public interface IVsExtensibility
    {
        void get_Properties(
            ISupportVSProperties pParent,
            object pdispPropObj,
            out Properties ppProperties);

        wizardResult RunWizardFile(
            string bstrWizFilename,
            int hwndOwner,
            ref object[] vContextParams);

        TextBuffer Get_TextBuffer(object pVsTextStream, IExtensibleObjectSite pParent);
        void EnterAutomationFunction();
        void ExitAutomationFunction();
        int IsInAutomationFunction();
        void GetUserControl(out bool fUserControl);
        void SetUserControl(bool fUserControl);
        void SetUserControlUnlatched(bool fUserControl);
        void LockServer(bool __MIDL_0010);
        int GetLockCount();
        bool TestForShutdown();
        Globals GetGlobalsObject(object ExtractFrom);
        ConfigurationManager GetConfigMgr(object pIVsProject, uint itemid);
        void FireMacroReset();
        Document GetDocumentFromDocCookie(int lDocCookie);
        void IsMethodDisabled(ref Guid pGUID, int dispid);
        void SetSuppressUI(bool In);
        void GetSuppressUI(ref bool pOut);
    }
}
