using System.Collections;
using EnvDTE;

namespace EnvDTE90
{
    public interface ExceptionSettings : IEnumerable
    {
        DTE DTE { get; }
        Debugger Parent { get; }
        int Count { get; }
        string Name { get; }
        bool SupportsExceptionCodes { get; }
        ExceptionSetting Item(object Index);
        new IEnumerator GetEnumerator();
        ExceptionSetting ItemFromCode(uint Code);
        ExceptionSetting NewException(string Name, uint Code);
        void Remove(object Index);
        void RemoveByCode(uint Code);
        void SetBreakWhenThrown(bool BreakWhenThrown, ExceptionSetting ExceptionSetting);
        void SetBreakWhenUserUnhandled(bool BreakWhenUserUnhandled, ExceptionSetting ExceptionSetting);
    }
}
