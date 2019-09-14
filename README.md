[![Incubator JetBrains Project](http://jb.gg/badges/incubator.svg)](https://confluence.jetbrains.com/display/ALL/JetBrains+on+GitHub)
[![Build status](https://ci.appveyor.com/api/projects/status/3k72xhgntrj5t9h2?svg=true)](https://ci.appveyor.com/project/kirillgla/jetbrains-envdte)

JetBrains.EnvDTE
----
*The problem*:  
Many projects use `EnvDTE` interfaces, which currently can only be accessed from a Microsoft Visual Studio instance. Such projects cannot migrate to Rider.

*The solution*:  
This project creates an assembly that looks exactly like Visual Studio EnvDTE, but can be obtained inside JetBrains Rider.

Instead of accessing COM, this DTE mock uses RD protocol to access project model info built by Rider

Build instructions:
----
```powershell
.\build.ps1
```
or
```bash
bash build.sh
```
