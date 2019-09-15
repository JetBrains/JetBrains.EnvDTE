using EnvDTE;

namespace EnvDTE80
{
    public delegate void _dispTextDocumentKeyPressEvents_BeforeKeyPressEventHandler(
        string Keypress,
        TextSelection Selection,
        bool InStatementCompletion,
        ref bool CancelKeypress);
}
