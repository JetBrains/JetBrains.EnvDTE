using System;
using System.Threading.Tasks;
using JetBrains.Core;
using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.ProjectsHost;
using JetBrains.Rd.Tasks;
using JetBrains.RdBackend.Common.Features.ProjectModel.View;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Host.Callback.Util
{
    public static class EnvDteCallbackProviderExtensions
    {
        public static void SetWithProjectSync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<TReq, IProject, TRes> func) where TReq : ProjectItemRequest =>
            endpoint.SetSync(req =>
            {
                var project = GetProjectItemOrThrow<TReq, IProject>(host, req);
                return func(req, project);
            });

        public static void SetWithProjectAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProject, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                var project = GetProjectItemOrThrow<TReq, IProject>(host, req);
                return await func(lifetime, req, project);
            });

        public static void SetWithProjectItemAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectItem, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                var projectItem = GetProjectItemOrThrow<TReq, IProjectItem>(host, req);
                return await func(lifetime, req, projectItem);
            });

        public static void SetWithProjectFolderAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectFolder, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                var projectFolder = GetProjectItemOrThrow<TReq, IProjectFolder>(host, req);
                return await func(lifetime, req, projectFolder);
            });

        public static void SetWithProjectFileAsync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectFile, Task<TRes>> func) where TReq : ProjectItemRequest =>
            endpoint.SetAsync(async (lifetime, req) =>
            {
                var projectFile = GetProjectItemOrThrow<TReq, IProjectFile>(host, req);
                return await func(lifetime, req, projectFile);
            });

        public static void SetWithProjectVoidAsync<TReq>(
            this IRdEndpoint<TReq, Unit> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProject, Task> func) where TReq : ProjectItemRequest =>
            endpoint.SetVoidAsync(async (lifetime, req) =>
            {
                var project = GetProjectItemOrThrow<TReq, IProject>(host, req);
                await func(lifetime, req, project);
            });

        public static void SetWithProjectItemVoidAsync<TReq>(
            this IRdEndpoint<TReq, Unit> endpoint,
            ProjectModelViewHost host,
            Func<Lifetime, TReq, IProjectItem, Task> func) where TReq : ProjectItemRequest =>
            endpoint.SetVoidAsync(async (lifetime, req) =>
            {
                var projectItem = GetProjectItemOrThrow<TReq, IProjectItem>(host, req);
                await func(lifetime, req, projectItem);
            });

        public static void SetWithProjectMarkSync<TReq, TRes>(
            this IRdEndpoint<TReq, TRes> endpoint,
            ProjectModelViewHost host,
            Func<TReq, IProjectMark, TRes> func) where TReq : ProjectItemRequest =>
            endpoint.SetSync(req =>
            {
                var projectMark = GetProjectMarkOrThrow(host, req);
                return func(req, projectMark);
            });

        private static TItem GetProjectItemOrThrow<TReq, TItem>(ProjectModelViewHost host, TReq req)
            where TReq : ProjectItemRequest where TItem : class, IProjectItem
        {
            var projectItem = host.GetItemById<TItem>(req.ProjectItemModel.Id);
            if (projectItem is null) throw new InvalidOperationException(
                $"{nameof(TItem)} not found for id: {req.ProjectItemModel.Id}." +
                " Project model probably changed, and id on the client side is outdated.");

            return projectItem;
        }

        private static IProjectMark GetProjectMarkOrThrow<TReq>(ProjectModelViewHost host, TReq req)
            where TReq : ProjectItemRequest
        {
            var project = GetProjectItemOrThrow<TReq, IProject>(host, req);

            var projectMark = project.GetProjectMark();
            if (projectMark is null)
                throw new InvalidOperationException($"Project mark not found for project: {project.Name}.");

            return projectMark;
        }
    }
}
