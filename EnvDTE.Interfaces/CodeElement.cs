﻿namespace EnvDTE
{
    public interface CodeElement
    {
        DTE DTE { get; }
        CodeElements Collection { get; }
        string Name { get; set; }
        string FullName { get; }
        ProjectItem ProjectItem { get; }
        vsCMElement Kind { get; }
        bool IsCodeType { get; }
        vsCMInfoLocation InfoLocation { get; }
        CodeElements Children { get; }
        string Language { get; }
        TextPoint StartPoint { get; }
        TextPoint EndPoint { get; }
        object ExtenderNames { get; }
        string ExtenderCATID { get; }
        object get_Extender(string ExtenderName);
        TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
    }
}
