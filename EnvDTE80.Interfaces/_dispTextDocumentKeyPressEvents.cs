using EnvDTE;

namespace EnvDTE80
{
    public interface _dispTextDocumentKeyPressEvents
    {
        void BeforeKeyPress(
            string Keypress,
            TextSelection Selection,
            bool InStatementCompletion,
            ref bool CancelKeypress);

        void AfterKeyPress(string Keypress, TextSelection Selection, bool InStatementCompletion);
    }
}
