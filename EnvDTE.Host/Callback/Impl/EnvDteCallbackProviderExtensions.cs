using System;
using JetBrains.Core;
using JetBrains.Rd.Tasks;
using JetBrains.ReSharper.Resources.Shell;

namespace JetBrains.EnvDTE.Host.Callback.Impl
{
    public static class EnvDteCallbackProviderExtensions
    {
        public static void SetWithReadLock<TRes>(this IRdEndpoint<Unit, TRes> endpoint, Func<TRes> func) =>
            endpoint.Set(
                _ =>
                {
                    using (ReadLockCookie.Create())
                    {
                        return func();
                    }
                }
            );

        public static void SetWithReadLock<TReq, TRes>(this IRdEndpoint<TReq, TRes> endpoint, Func<TReq, TRes> func) =>
            endpoint.Set(
                argument =>
                {
                    using (ReadLockCookie.Create())
                    {
                        return func(argument);
                    }
                }
            );
    }
}
