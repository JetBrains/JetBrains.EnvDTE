using System;

namespace EnvDTE
{
    public sealed class _dispTextEditorEvents_SinkHelper : _dispTextEditorEvents
    {
        public int m_dwCookie;
        public _dispTextEditorEvents_LineChangedEventHandler m_LineChangedDelegate;

        internal _dispTextEditorEvents_SinkHelper()
        {
        }

        public void LineChanged(TextPoint A_1, TextPoint A_2, int A_3)
        {
            throw new NotImplementedException();
        }
    }
}
