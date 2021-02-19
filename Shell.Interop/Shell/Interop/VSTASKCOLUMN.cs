namespace Microsoft.VisualStudio.Shell.Interop
{
    public struct VSTASKCOLUMN
    {
        public int iField;

        public string bstrHeading;

        public int iImage;

        public int fShowSortArrow;

        public int fAllowUserSort;

        public int fVisibleByDefault;

        public int fAllowHide;

        public int fSizeable;

        public int fMoveable;

        public int iDefaultSortPriority;

        public int fDescendingSort;

        public int cxMinWidth;

        public int cxDefaultWidth;

        public int fDynamicSize;

        public string bstrCanonicalName;

        public string bstrLocalizedName;

        public string bstrTip;

        public int fFitContent;
    }
}
