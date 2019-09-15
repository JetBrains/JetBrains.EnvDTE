using System;
using System.Collections;
using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Core;

namespace JetBrains.EnvDTE.Impl
{
    public class SolutionImplementation : SolutionClass
    {
        [NotNull]
        private DteImplementation Implementation { get; }

        internal SolutionImplementation([NotNull] DteImplementation dte) => Implementation = dte;
        public override Project Item(object index) => base.Item(index);
        public override IEnumerator GetEnumerator() => base.GetEnumerator();
        public override DTE DTE => Implementation;
        public override DTE Parent => Implementation;
        public override int Count { get; }
        public override string FileName => Implementation.DteProtocolModel.Solution_FileName.Sync(Unit.Instance);

        public override void SaveAs(string FileName)
        {
            base.SaveAs(FileName);
        }

        public override Project AddFromTemplate(string FileName, string Destination, string ProjectName,
            bool Exclusive = false) => base.AddFromTemplate(FileName, Destination, ProjectName, Exclusive);

        public override Project AddFromFile(string FileName, bool Exclusive = false) =>
            base.AddFromFile(FileName, Exclusive);

        public override void Open(string FileName)
        {
            base.Open(FileName);
        }

        public override void Close(bool SaveFirst = false)
        {
            base.Close(SaveFirst);
        }

        public override Properties Properties { get; }
        public override bool IsDirty { get; set; }

        public override void Remove(Project proj)
        {
            base.Remove(proj);
        }

        public override string get_TemplatePath(string ProjectType) => base.get_TemplatePath(ProjectType);
        public override string FullName { get; }
        public override bool Saved { get; set; }
        public override Globals Globals { get; }
        public override AddIns AddIns => throw new NotImplementedException();
        public override object get_Extender(string ExtenderName) => base.get_Extender(ExtenderName);
        public override object ExtenderNames { get; }
        public override string ExtenderCATID { get; }
        public override bool IsOpen { get; }
        public override SolutionBuild SolutionBuild { get; }

        public override void Create(string Destination, string Name)
        {
            base.Create(Destination, Name);
        }

        public override Projects Projects { get; }
        public override ProjectItem FindProjectItem(string FileName) => base.FindProjectItem(FileName);

        public override string ProjectItemsTemplatePath(string ProjectKind) =>
            base.ProjectItemsTemplatePath(ProjectKind);
    }
}
