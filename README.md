
[![Incubator JetBrains Project](http://jb.gg/badges/incubator.svg)](https://confluence.jetbrains.com/display/ALL/JetBrains+on+GitHub)

JetBrains.EnvDTE
----
*The problem*:  
Many projects use `EnvDTE` interfaces, which currently can only be accessed from a Microsoft Visual Studio instance. Such projects cannot migrate to Rider.

*The solution*:  
This project creates an assembly that looks exactly like Visual Studio EnvDTE, but can be obtained inside JetBrains Rider.

Instead of accessing COM, this DTE mock uses RD protocol to access project model info built by Rider

Build instructions:
----
```bash
cd Protocol
gradlew
cd ..
msbuild
```
