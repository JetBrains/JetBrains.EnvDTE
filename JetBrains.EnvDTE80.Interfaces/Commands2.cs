
using System.Collections;
using EnvDTE;


namespace EnvDTE80
{
	public interface Commands2 : Commands
	{
		new DTE DTE { get; }
		new DTE Parent { get; }
		new int Count { get; }
		new void Add(string Guid, int ID, ref object Control);
		new void Raise(string Guid, int ID, ref object CustomIn, ref object CustomOut);
		new void CommandInfo(object CommandBarControl, out string Guid, out int ID);
		new Command Item(object index, int ID = -1);
		new IEnumerator GetEnumerator();

		new Command AddNamedCommand(
			AddIn AddInInstance,
			string Name,
			string ButtonText,
			string Tooltip,
			bool MSOButton,
			int Bitmap = 0,
			ref object[] ContextUIGUIDs = null,
			int vsCommandDisabledFlagsValue = 16);

		new object AddCommandBar(
			string Name,
			vsCommandBarType Type,
			object CommandBarParent,
			int Position = 1);

		new void RemoveCommandBar(object CommandBar);

		Command AddNamedCommand2(
			AddIn AddInInstance,
			string Name,
			string ButtonText,
			string Tooltip,
			bool MSOButton,
			object Bitmap,
			ref object[] ContextUIGUIDs,
			int vsCommandStatusValue = 3,
			int CommandStyleFlags = 3,
			vsCommandControlType ControlType = vsCommandControlType.vsCommandControlTypeButton);

		void UpdateCommandUI(bool PerformImmediately);
	}
}
