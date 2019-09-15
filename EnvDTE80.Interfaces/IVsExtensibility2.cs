using System;
using EnvDTE;

namespace EnvDTE80
{
    public interface IVsExtensibility2 : IVsExtensibility
    {
        new void get_Properties(
            ISupportVSProperties pParent,
            object pdispPropObj,
            out Properties ppProperties);

        new wizardResult RunWizardFile(
            string bstrWizFilename,
            int hwndOwner,
            ref object[] vContextParams);

        new TextBuffer Get_TextBuffer(object pVsTextStream, IExtensibleObjectSite pParent);
        new void EnterAutomationFunction();
        new void ExitAutomationFunction();
        new int IsInAutomationFunction();
        new void GetUserControl(out bool fUserControl);
        new void SetUserControl(bool fUserControl);
        new void SetUserControlUnlatched(bool fUserControl);
        new void LockServer(bool __MIDL_0010);
        new int GetLockCount();
        new bool TestForShutdown();
        new Globals GetGlobalsObject(object ExtractFrom);
        new ConfigurationManager GetConfigMgr(object pIVsProject, uint itemid);
        new void FireMacroReset();
        new Document GetDocumentFromDocCookie(int lDocCookie);
        new void IsMethodDisabled(ref Guid pGUID, int dispid);
        new void SetSuppressUI(bool In);
        new void GetSuppressUI(ref bool pOut);
        void FireProjectsEvent_ItemAdded(Project Project);
        void FireProjectsEvent_ItemRemoved(Project Project);
        void FireProjectsEvent_ItemRenamed(Project Project, string OldName);
        void FireProjectItemsEvent_ItemAdded(ProjectItem ProjectItem);
        void FireProjectItemsEvent_ItemRemoved(ProjectItem ProjectItem);
        void FireProjectItemsEvent_ItemRenamed(ProjectItem ProjectItem, string OldName);
        UIHierarchy BuildUIHierarchyFromTree(int hwnd, Window pParent);
        void FireCodeModelEvent(int dispid, CodeElement pElement, vsCMChangeKind changeKind);
        void IsFireCodeModelEventNeeded(ref bool vbNeeded);

        int RunWizardFileEx(
            string bstrWizFilename,
            int hwndOwner,
            ref object[] vContextParams,
            ref object[] vCustomParams);

        void FireCodeModelEvent3(
            int dispid,
            object pParent,
            CodeElement pElement,
            vsCMChangeKind changeKind);
    }
}
