using EnvDTE;

namespace EnvDTE80
{
    public interface CodeClass2 : CodeClass
    {
        new DTE DTE { get; }
        new CodeElements Collection { get; }
        new string Name { get; set; }
        new string FullName { get; }
        new ProjectItem ProjectItem { get; }
        new vsCMElement Kind { get; }
        new bool IsCodeType { get; }
        new vsCMInfoLocation InfoLocation { get; }
        new CodeElements Children { get; }
        new string Language { get; }
        new TextPoint StartPoint { get; }
        new TextPoint EndPoint { get; }
        new object ExtenderNames { get; }
        new string ExtenderCATID { get; }
        new object Parent { get; }
        new CodeNamespace Namespace { get; }
        new CodeElements Bases { get; }
        new CodeElements Members { get; }
        new vsCMAccess Access { set; get; }
        new CodeElements Attributes { get; }
        new string DocComment { get; set; }
        new string Comment { get; set; }
        new CodeElements DerivedTypes { get; }
        new CodeElements ImplementedInterfaces { get; }
        new bool IsAbstract { get; set; }
        vsCMClassKind ClassKind { get; set; }
        CodeElements PartialClasses { get; }
        vsCMDataTypeKind DataTypeKind { get; set; }
        CodeElements Parts { get; }
        vsCMInheritanceKind InheritanceKind { get; set; }
        bool IsGeneric { get; }
        bool IsShared { get; set; }
        new object get_Extender(string ExtenderName);
        new TextPoint GetStartPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        new TextPoint GetEndPoint(vsCMPart Part = vsCMPart.vsCMPartWholeWithAttributes);
        new CodeElement AddBase(object Base, object Position);
        new CodeAttribute AddAttribute(string Name, string Value, object Position);
        new void RemoveBase(object Element);
        new void RemoveMember(object Element);
        new bool get_IsDerivedFrom(string FullName);
        new CodeInterface AddImplementedInterface(object Base, object Position);

        new CodeFunction AddFunction(
            string Name,
            vsCMFunction Kind,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
            object Location = null);

        new CodeVariable AddVariable(
            string Name,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
            object Location = null);

        new CodeProperty AddProperty(
            string GetterName,
            string PutterName,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault,
            object Location = null);

        new CodeClass AddClass(
            string Name,
            object Position = null,
            object Bases = null,
            object ImplementedInterfaces = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        new CodeStruct AddStruct(
            string Name,
            object Position = null,
            object Bases = null,
            object ImplementedInterfaces = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        new CodeEnum AddEnum(
            string Name,
            object Position = null,
            object Bases = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        new CodeDelegate AddDelegate(
            string Name,
            object Type,
            object Position = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

        new void RemoveInterface(object Element);

        CodeEvent AddEvent(
            string Name,
            string FullDelegateName,
            bool CreatePropertyStyleEvent = false,
            object Location = null,
            vsCMAccess Access = vsCMAccess.vsCMAccessDefault);
    }
}
