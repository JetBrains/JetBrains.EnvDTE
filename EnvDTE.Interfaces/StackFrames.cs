using System.Collections;

namespace EnvDTE
{
    public interface StackFrames : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        StackFrame Item(object index);
        new IEnumerator GetEnumerator();
    }
}
