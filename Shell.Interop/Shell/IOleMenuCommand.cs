using System;

namespace Microsoft.VisualStudio.Shell
{
    public interface IOleMenuCommand
    {
        bool DynamicItemMatch(int cmdId);

        void Invoke(object inArg, IntPtr outArg);

        string ParametersDescription { get; set; }

        string Text { get; set; }
    }
}
