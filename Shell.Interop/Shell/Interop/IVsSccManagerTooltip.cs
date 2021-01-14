namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSccManagerTooltip
    {
        int GetGlyphTipText(object phierHierarchy, uint itemidNode, out string pbstrTooltipText);
    }
}
