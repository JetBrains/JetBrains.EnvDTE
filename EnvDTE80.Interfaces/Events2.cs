using EnvDTE;

namespace EnvDTE80
{
    public interface Events2 : Events
    {
        new SelectionEvents SelectionEvents { get; }
        new SolutionEvents SolutionEvents { get; }
        new BuildEvents BuildEvents { get; }
        new FindEvents FindEvents { get; }
        new DTEEvents DTEEvents { get; }
        new ProjectItemsEvents SolutionItemsEvents { get; }
        new ProjectItemsEvents MiscFilesEvents { get; }
        new DebuggerEvents DebuggerEvents { get; }
        ProjectItemsEvents ProjectItemsEvents { get; }
        ProjectsEvents ProjectsEvents { get; }
        DebuggerProcessEvents DebuggerProcessEvents { get; }
        DebuggerExpressionEvaluationEvents DebuggerExpressionEvaluationEvents { get; }
        PublishEvents PublishEvents { get; }
        new object get_CommandBarEvents(object CommandBarControl);
        new CommandEvents get_CommandEvents(string Guid = "{00000000-0000-0000-0000-000000000000}", int ID = 0);
        new WindowEvents get_WindowEvents(Window WindowFilter = null);
        new OutputWindowEvents get_OutputWindowEvents(string Pane = "");
        new TaskListEvents get_TaskListEvents(string Filter = "");
        new DocumentEvents get_DocumentEvents(Document Document = null);
        new TextEditorEvents get_TextEditorEvents(TextDocument TextDocumentFilter = null);
        new object GetObject(string Name);

        TextDocumentKeyPressEvents get_TextDocumentKeyPressEvents(
            TextDocument TextDocument = null);

        CodeModelEvents get_CodeModelEvents(CodeElement Reserved = null);
        WindowVisibilityEvents get_WindowVisibilityEvents(Window WindowFilter = null);
    }
}
