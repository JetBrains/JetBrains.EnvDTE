using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
  
  
  
  public interface Events
  {
    
    
    
    object get_CommandBarEvents( object CommandBarControl);

    
    
    
    CommandEvents get_CommandEvents( string Guid = "{00000000-0000-0000-0000-000000000000}",  int ID = 0);

    
    SelectionEvents SelectionEvents {   get; }

    
    SolutionEvents SolutionEvents {   get; }

    
    BuildEvents BuildEvents {   get; }

    
    
    
    WindowEvents get_WindowEvents( Window WindowFilter = null);

    
    
    
    OutputWindowEvents get_OutputWindowEvents( string Pane = "");

    
    FindEvents FindEvents {   get; }

    
    
    
    TaskListEvents get_TaskListEvents( string Filter = "");

    
    DTEEvents DTEEvents {   get; }

    
    
    
    DocumentEvents get_DocumentEvents( Document Document = null);

    
    ProjectItemsEvents SolutionItemsEvents {   get; }

    
    ProjectItemsEvents MiscFilesEvents {   get; }

    
    DebuggerEvents DebuggerEvents {   get; }

    
    
    
    TextEditorEvents get_TextEditorEvents( TextDocument TextDocumentFilter = null);

    
    
    
    object GetObject( string Name);
  }
}
