using System;


namespace Microsoft.VisualStudio.Designer.Interfaces
{
    public interface IVSMDDesigner
    {
        Guid CommandGuid { get; }

        object View { get; }

        object SelectionContainer { get; }

        void Dispose();

        void Flush();

        void GetLoadError();
    }
}
