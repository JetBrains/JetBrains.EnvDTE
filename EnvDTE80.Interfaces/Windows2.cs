using System.Collections;
using EnvDTE;

namespace EnvDTE80
{
    public interface Windows2 : Windows
    {
        new int Count { get; }
        new DTE DTE { get; }
        new DTE Parent { get; }
        new Window Item(object index);
        new IEnumerator GetEnumerator();

        new Window CreateToolWindow(
            AddIn AddInInst,
            string ProgID,
            string Caption,
            string GuidPosition,
            ref object DocObj);

        new Window CreateLinkedWindowFrame(
            Window Window1,
            Window Window2,
            vsLinkedWindowType Link);

        Window CreateToolWindow2(
            AddIn Addin,
            string Assembly,
            string Class,
            string Caption,
            string GuidPosition,
            ref object ControlObject);
    }
}
