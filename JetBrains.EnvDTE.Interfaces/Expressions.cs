using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.CustomMarshalers;

namespace EnvDTE
{
  
  
  
  public interface Expressions : IEnumerable
  {
    
    
    
    Expression Item( object index);

    
    
    
    
    new IEnumerator GetEnumerator();

    
    DTE DTE {   get; }

    
    Debugger Parent {   get; }

    
    int Count {  get; }
  }
}
