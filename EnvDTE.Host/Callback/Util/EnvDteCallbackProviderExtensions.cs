using System;
using JetBrains.Application.Threading;
using JetBrains.Core;
using JetBrains.Rd.Tasks;

namespace JetBrains.EnvDTE.Host.Callback.Util
{
    public static class EnvDteCallbackProviderExtensions
    {
        public static void SetWithReadLock<TRes>(
            this IRdEndpoint<Unit, TRes> endpoint,
            IShellLocks locks,
            Func<TRes> func) =>
            endpoint.SetAsync((lifetime, _) => locks.StartReadActionAsync(lifetime, func));

        public static void SetWithReadLock<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            IShellLocks locks,
            Func<TReq, TRes> func) =>
            endpoint.SetAsync((lifetime, req) => locks.StartReadActionAsync(lifetime, () => func(req)));
    }
}
