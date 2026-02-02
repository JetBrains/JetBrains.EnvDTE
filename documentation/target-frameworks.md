# Target Frameworks

Some client‑side assemblies target multiple frameworks to stay compatible with all `EnvDTE` consumers:

- **`netstandard2.0`** — Used by the Package Manager Console plugin because its PowerShell module targets `netstandard2.0`.
- **`net472`** — Used by the ForTea plugin. The T4 compiler already provides the standard .NET Framework reference set, so templates compile without extra assembly directives. This, for example, wouldn't be the case if `netstandard2.0` builds were used, because they would require `netstandard.dll` to be supplied.
- **`netcoreapp3.0`** — Used by the WinForms Designer, which runs on .NET Core.