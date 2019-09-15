using System;

namespace EnvDTE80
{
    internal sealed class _dispPublishEvents_EventProvider : _dispPublishEvents_Event, IDisposable
    {
        public _dispPublishEvents_EventProvider(object A_1)
        {
        }

        public event _dispPublishEvents_OnPublishBeginEventHandler OnPublishBegin;
        public event _dispPublishEvents_OnPublishDoneEventHandler OnPublishDone;

        public void Dispose()
        {
        }

        public void Finalize()
        {
        }
    }
}
