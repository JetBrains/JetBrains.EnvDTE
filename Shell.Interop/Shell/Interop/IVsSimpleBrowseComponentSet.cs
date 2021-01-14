using System;

namespace Microsoft.VisualStudio.Shell.Interop
{
    public interface IVsSimpleBrowseComponentSet
    {
        new int put_ComponentsListOptions(uint dwOptions);

        new int get_ComponentsListOptions(out uint pdwOptions);

        new int put_ChildListOptions(uint dwOptions);

        new int get_ChildListOptions(out uint pdwOptions);

        new int GetList2(
            uint ListType,
            uint flags,
            VSOBSEARCHCRITERIA2[] pobSrch,
            IVsObjectList2 pExtraListToCombineWith,
            out IVsObjectList2 ppIVsObjectList2);

        new int GetSupportedCategoryFields2(int Category, out uint pgrfCatField);

        new int CreateNavInfo(
            ref Guid guidLib,
            object[] rgSymbolNodes,
            uint ulcNodes,
            out IVsNavInfo ppNavInfo);

        new int UpdateCounter(out uint pCurUpdate);

        int put_RootNavInfo(IVsNavInfo pRootNavInfo);

        int get_RootNavInfo(out IVsNavInfo pRootNavInfo);

        int put_Owner(object pOwner);

        int get_Owner(out object ppOwner);

        int FindComponent(
            ref Guid guidLib,
            object[] pcsdComponent,
            out IVsNavInfo ppRealLibNavInfo,
            object[] pcsdExistingComponent);

        int AddComponent(
            ref Guid guidLib,
            object[] pcsdComponent,
            out IVsNavInfo ppRealLibNavInfo,
            object[] pcsdAddedComponent);

        int RemoveComponent(IVsNavInfo pRealLibNavInfo);

        int RemoveAllComponents();
    }
}
