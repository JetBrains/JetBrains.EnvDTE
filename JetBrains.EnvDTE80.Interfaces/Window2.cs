
using EnvDTE;


namespace EnvDTE80
{
	public interface Window2 : Window
	{
		new Windows Collection { get; }
		new bool Visible { get; set; }
		new int Left { get; set; }
		new int Top { get; set; }
		new int Width { get; set; }
		new int Height { get; set; }
		new vsWindowState WindowState { get; set; }
		new vsWindowType Type { get; }
		new LinkedWindows LinkedWindows { get; }
		new Window LinkedWindowFrame { get; }
		new int HWnd { get; }
		new string Kind { get; }
		new string ObjectKind { get; }
		new object Object { get; }
		new ProjectItem ProjectItem { get; }
		new Project Project { get; }
		new DTE DTE { get; }
		new Document Document { get; }
		new object Selection { get; }
		new bool Linkable { get; set; }
		new string this[] { get; set; }
		new bool IsFloating { get; set; }
		new bool AutoHides { get; set; }
		new ContextAttributes ContextAttributes { get; }
		object CommandBars { get; }
		new void SetFocus();
		new void SetKind(vsWindowType eKind);
		new void Detach();
		new void Attach(int lWindowHandle);
		new object get_DocumentData(string bstrWhichData = "");
		new void Activate();
		new void Close(vsSaveChanges SaveChanges = vsSaveChanges.vsSaveChangesNo);
		new void SetSelectionContainer(ref object[] Objects);
		new void SetTabPicture(object Picture);
	}
}
