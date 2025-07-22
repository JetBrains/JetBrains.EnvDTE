using Mono.Cecil;
using Mono.Cecil.Rocks;

var path = args.Length == 1 ? args[0] : throw new ArgumentException($"There is {args.Length} args ({string.Join(", ", args)}) instead of 1: path");
var fileName = File.Exists(path) ? path : throw new ArgumentException("Invalid path: " + path);

var readerParameters = new ReaderParameters { ReadWrite = true };
using var assemblyDefinition = AssemblyDefinition.ReadAssembly(fileName, readerParameters);

var parameterType = assemblyDefinition.MainModule.ImportReference(typeof (UIntPtr));

foreach (var module in assemblyDefinition.Modules)
{
    foreach (var self in module.Types.Where<TypeDefinition>(type => type.BaseType?.FullName == "System.MulticastDelegate"))
    {
        var methodDefinition = self.GetConstructors().Single<MethodDefinition>();
        var parameterDefinition = methodDefinition.Parameters.SingleOrDefault<ParameterDefinition>(type => type.Name == "method" && type.ParameterType.FullName == "System.IntPtr");
        if (parameterDefinition != null)
        {
            methodDefinition.Parameters.Remove(parameterDefinition);
            var parameterDefinition2 = new ParameterDefinition(parameterDefinition.Name, parameterDefinition.Attributes, parameterType);
            methodDefinition.Parameters.Add(parameterDefinition2);
        }
    }
}

assemblyDefinition.Write(new WriterParameters
    {
        WriteSymbols = readerParameters.ReadSymbols
    }
);
