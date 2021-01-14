namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDCodeDomCreator
    {
        IVSMDCodeDomProvider CreateCodeDomProvider(object pHier, int itemid);
    }
}
