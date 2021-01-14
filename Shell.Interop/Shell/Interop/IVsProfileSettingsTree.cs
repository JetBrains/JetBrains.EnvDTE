namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsProfileSettingsTree
    {
    int GetChildCount(out int pCount);

    int GetChild( int index,  out IVsProfileSettingsTree ppChildTree);

    int GetEnabledChildCount(out int pCount);

    int GetDisplayName( out string pbstrName);

    int GetDescription( out string pbstrDescription);

    int GetCategory( out string pbstrCategory);

    int GetRegisteredName( out string pbstrRegisteredName);

    int GetNameForID( out string pbstrNameForID);

    int GetFullPath( out string pbstrFullPath);

    int GetPackage( out string pbstrPackage);

    int GetIsAutomationPropBased( out int pfAutoProp);

    int GetEnabled( out int pfEnabled);

    int SetEnabled( int fEnabled,  int fIncludeChildren);

    int GetVisible( out int pfVisible);

    int GetAlternatePath( out string pbstrAlternatePath);

    int GetIsPlaceholder( out int pfPlaceholder);

    int GetRepresentedNode( out IVsProfileSettingsTree ppRepresentedNode);

    int GetSecurityLevel( out uint pSecurityLevel);

    int GetSensitivityLevel( out uint pSensitivityLevel);

    int FindChildTree( string bstrNameSearch,  out IVsProfileSettingsTree ppChildTree);

    int AddChildTree( IVsProfileSettingsTree pChildTree);

    int RevisePlacements(
       IVsProfileSettingsTree pTreeRoot,
       IVsProfileSettingsTree pTreeRootBasis,
       string bstrCurrentParent);
    }
}
