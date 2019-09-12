
using EnvDTE;


namespace EnvDTE80
{
	public delegate void _dispTextDocumentKeyPressEvents_AfterKeyPressEventHandler(
		string Keypress,
		TextSelection Selection,
		bool InStatementCompletion);
}
