using System;

namespace EnvDTE
{
	public sealed class _dispProjectItemsEvents_SinkHelper : _dispProjectItemsEvents
	{
		public int m_dwCookie;
		public _dispProjectItemsEvents_ItemAddedEventHandler m_ItemAddedDelegate;
		public _dispProjectItemsEvents_ItemRemovedEventHandler m_ItemRemovedDelegate;
		public _dispProjectItemsEvents_ItemRenamedEventHandler m_ItemRenamedDelegate;

		internal _dispProjectItemsEvents_SinkHelper()
		{
		}

		public void ItemAdded(ProjectItem A_1)
		{
			throw new NotImplementedException();
		}

		public void ItemRemoved(ProjectItem A_1)
		{
			throw new NotImplementedException();
		}

		public void ItemRenamed(ProjectItem A_1, string A_2)
		{
			throw new NotImplementedException();
		}
	}
}
