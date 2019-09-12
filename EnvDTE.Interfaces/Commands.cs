
using System.Collections;


namespace EnvDTE
{
	public interface Commands : IEnumerable
	{
		DTE DTE { get; }
		DTE Parent { get; }
		int Count { get; }
		void Add(string Guid, int ID, ref object Control);
		void Raise(string Guid, int ID, ref object CustomIn, ref object CustomOut);
		void CommandInfo(object CommandBarControl, out string Guid, out int ID);
		Command Item(object index, int ID = -1);
		new IEnumerator GetEnumerator();

		Command AddNamedCommand(
			AddIn AddInInstance,
			string Name,
			string ButtonText,
			string Tooltip,
			bool MSOButton,
			int Bitmap = 0,
			object[] ContextUIGUIDs = null,
			int vsCommandDisabledFlagsValue = 16);

		object AddCommandBar(
			string Name,
			vsCommandBarType Type,
			object CommandBarParent,
			int Position = 1);

		void RemoveCommandBar(object CommandBar);
	}
}
