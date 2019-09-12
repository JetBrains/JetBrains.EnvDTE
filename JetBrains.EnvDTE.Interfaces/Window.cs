namespace EnvDTE
{
	public interface Window
	{
		Windows Collection { get; }
		bool Visible { get; set; }
		int Left { get; set; }
		int Top { get; set; }
		int Width { get; set; }
		int Height { get; set; }
		vsWindowState WindowState { get; set; }
		vsWindowType Type { get; }
		LinkedWindows LinkedWindows { get; }
		Window LinkedWindowFrame { get; }
		int HWnd { get; }
		string Kind { get; }
		string ObjectKind { get; }
		object Object { get; }
		ProjectItem ProjectItem { get; }
		Project Project { get; }
		DTE DTE { get; }
		Document Document { get; }
		object Selection { get; }
		bool Linkable { get; set; }
		string this[] { get; set; }
		bool IsFloating { get; set; }
		bool AutoHides { get; set; }
		ContextAttributes ContextAttributes { get; }
		void SetFocus();
		void SetKind(vsWindowType eKind);
		void Detach();
		void Attach(int lWindowHandle);
		object get_DocumentData(string bstrWhichData = "");
		void Activate();
		void Close(vsSaveChanges SaveChanges = vsSaveChanges.vsSaveChangesNo);
		void SetSelectionContainer(ref object[] Objects);
		void SetTabPicture(object Picture);
	}
}
