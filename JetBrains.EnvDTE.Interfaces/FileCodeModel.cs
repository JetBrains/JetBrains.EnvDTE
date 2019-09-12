using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EnvDTE
{
  
  
  
  public interface FileCodeModel
  {
    
    DTE DTE {   get; }

    
    ProjectItem Parent {   get; }

    
    string Language {   get; }

    
    CodeElements CodeElements {   get; }

    
    
    
    CodeElement CodeElementFromPoint( TextPoint Point, vsCMElement Scope);

    
    
    
    CodeNamespace AddNamespace( string Name,  object Position);

    
    
    
    CodeClass AddClass(
       string Name,
       object Position,
       object Bases,
       object ImplementedInterfaces,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeInterface AddInterface(
       string Name,
       object Position,
       object Bases,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeFunction AddFunction(
       string Name,
      vsCMFunction Kind,
       object Type,
       object Position,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeVariable AddVariable(
       string Name,
       object Type,
       object Position,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeAttribute AddAttribute( string Name,  string Value,  object Position);

    
    
    
    CodeStruct AddStruct(
       string Name,
       object Position,
       object Bases,
       object ImplementedInterfaces,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeEnum AddEnum( string Name,  object Position,  object Bases, vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    
    CodeDelegate AddDelegate(
       string Name,
       object Type,
       object Position,
      vsCMAccess Access = vsCMAccess.vsCMAccessDefault);

    
    
    void Remove( object Element);
  }
}
