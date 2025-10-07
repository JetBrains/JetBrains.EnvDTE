using System;
using System.Threading.Tasks;
using JetBrains.Core;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;
using JetBrains.Util;
using JetBrains.Util.Logging;

namespace JetBrains.EnvDTE.Host.Callback.Util
{
    public static class EnvDteCallbackProviderExtensions
    {
        private static readonly ILogger Log = Logger.GetLogger("EnvDTE.Host.Callback");

        public static void SetWithProjectSync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<TReq, IProject, TRes> func) where TReq : ProjectItemRequest =>
            endpoint.SetSync(req =>
            {
                if (!TryGetProjectItem<TReq, IProject>(host, req, out var project))
                    return default;

                return func(req, project);
            });

        public static void SetWithProjectAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProject, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProject>(host, req, out var project))
                    return default;

                return await func(lifetime, req, project);
            });

        public static void SetWithProjectItemAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectItem, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProjectItem>(host, req, out var projectItem))
                    return default;

                return await func(lifetime, req, projectItem);
            });

        public static void SetWithProjectFolderAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectFolder, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProjectFolder>(host, req, out var projectFolder))
                    return default;

                return await func(lifetime, req, projectFolder);
            });

        public static void SetWithProjectFileAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectFile, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProjectFile>(host, req, out var projectFile))
                    return default;

                return await func(lifetime, req, projectFile);
            });

        public static void SetWithProjectVoidAsync<TReq>(
            this IRdEndpoint<TReq, Unit> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProject, Task> func) where TReq : ProjectItemRequest =>
            endpoint.SetVoidAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProject>(host, req, out var project))
                    return;

                await func(lifetime, req, project);
            });

        public static void SetWithProjectItemVoidAsync<TReq>(
            this IRdEndpoint<TReq, Unit> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectItem, Task> func) where TReq : ProjectItemRequest =>
            endpoint.SetVoidAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectItem<TReq, IProjectItem>(host, req, out var projectItem))
                    return;

                await func(lifetime, req, projectItem);
            });

        public static void SetWithProjectMarkSync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<TReq, IProjectMark, TRes> func) where TReq : ProjectItemRequest =>
            endpoint.SetSync(req =>
            {
                if (!TryGetProjectMark(host, req, out var projectMark))
                    return default;

                return func(req, projectMark);
            });

        public static void SetWithProjectMarkVoidAsync<TReq>(
            this IRdEndpoint<TReq, Unit> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectMark, Task> func) where TReq : ProjectItemRequest =>
            endpoint.SetVoidAsync(async (lifetime, req) =>
            {
                if (!TryGetProjectMark(host, req, out var projectMark))
                    return;

                await func(lifetime, req, projectMark);
            });

        private static bool TryGetProjectItem<TReq, TItem>(
            ProjectModelViewHost host,
            TReq req,
            out TItem projectItem)
            where TReq : ProjectItemRequest where TItem : class, IProjectItem
        {
            projectItem = host.GetItemById<TItem>(req.ProjectItemModel.Id);
            if (projectItem is null) throw new InvalidOperationException(
                $"{nameof(TItem)} not found for id: {req.ProjectItemModel.Id}." +
                " Project model probably changed, and id on the client side is outdated.");

            return true;
        }

        private static bool TryGetProjectMark<TReq>(
            ProjectModelViewHost host,
            TReq req,
            out IProjectMark projectMark) where TReq : ProjectItemRequest
        {
            projectMark = null;

            if (!TryGetProjectItem<TReq, IProject>(host, req, out var project))
                return false;

            projectMark = project.GetProjectMark();
            if (projectMark is null)
            {
                Log.Warn($"Project mark not found for project: {project.Name}.");
                return false;
            }

            return true;
        }
    }
}
