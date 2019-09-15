using System.Collections;

namespace EnvDTE
{
    public interface Windows : IEnumerable
    {
        int Count { get; }
        DTE DTE { get; }
        DTE Parent { get; }
        Window Item(object index);
        new IEnumerator GetEnumerator();

        Window CreateToolWindow(
            AddIn AddInInst,
            string ProgID,
            string Caption,
            string GuidPosition,
            ref object DocObj);

        Window CreateLinkedWindowFrame(Window Window1, Window Window2, vsLinkedWindowType Link);
    }
}
