using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
  
  
  
  public interface Expression
  {
    
    
    string this[] {   get; }

    
    string Type {   get; }

    
    Expressions DataMembers {   get; }

    
    string Value {   get;   set; }

    
    bool IsValidValue {  get; }

    
    DTE DTE {   get; }

    
    Debugger Parent {   get; }

    
    Expressions Collection {   get; }
  }
}
