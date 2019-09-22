Consider reference (for example, class) and value (for example, struct) types using SOS.dll, WinDbg in invoking virtual, non-virtual, System.Object methods (overriden and not overriden), interface methods, method tables, EEClass struct.

Create simple .NET Core console app:
```
dotnet new console
```
Change [Program.cs](UsingWinDbgAndSos/Program.cs)

Build and run app:
```
dotnet build
dotnet run
```
Launch WinDbg and attach to dotnet.exe process.
We can see the following
```
Microsoft (R) Windows Debugger Version 10.0.18362.1 AMD64
Copyright (c) Microsoft Corporation. All rights reserved.

*** wait with pending attach
Symbol search path is: srv*
Executable search path is: 
ModLoad: 00007ff7`98310000 00007ff7`98337000   C:\Program Files\dotnet\dotnet.exe
ModLoad: 00007ffc`d3c50000 00007ffc`d3e20000   C:\Windows\SYSTEM32\ntdll.dll
ModLoad: 00007ffc`d3a00000 00007ffc`d3aac000   C:\Windows\System32\KERNEL32.DLL
ModLoad: 00007ffc`d04a0000 00007ffc`d06bd000   C:\Windows\System32\KERNELBASE.dll
ModLoad: 00007ffc`d0960000 00007ffc`d0a54000   C:\Windows\System32\ucrtbase.dll
ModLoad: 00007ffc`bc870000 00007ffc`bc8d5000   C:\Program Files\dotnet\host\fxr\2.2.6\hostfxr.dll
ModLoad: 00007ffc`bc7d0000 00007ffc`bc862000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\hostpolicy.dll
ModLoad: 00007ffc`a56c0000 00007ffc`a5c86000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\coreclr.dll
ModLoad: 00007ffc`d3800000 00007ffc`d38a2000   C:\Windows\System32\ADVAPI32.dll
ModLoad: 00007ffc`d32a0000 00007ffc`d333e000   C:\Windows\System32\msvcrt.dll
ModLoad: 00007ffc`d3240000 00007ffc`d3299000   C:\Windows\System32\sechost.dll
ModLoad: 00007ffc`d12c0000 00007ffc`d13e1000   C:\Windows\System32\RPCRT4.dll
ModLoad: 00007ffc`d38c0000 00007ffc`d39f8000   C:\Windows\System32\ole32.dll
ModLoad: 00007ffc`d19a0000 00007ffc`d1c65000   C:\Windows\System32\combase.dll
ModLoad: 00007ffc`d07e0000 00007ffc`d084a000   C:\Windows\System32\bcryptPrimitives.dll
ModLoad: 00007ffc`d11e0000 00007ffc`d1214000   C:\Windows\System32\GDI32.dll
ModLoad: 00007ffc`d0310000 00007ffc`d0491000   C:\Windows\System32\gdi32full.dll
ModLoad: 00007ffc`d17c0000 00007ffc`d1925000   C:\Windows\System32\USER32.dll
ModLoad: 00007ffc`d0710000 00007ffc`d072e000   C:\Windows\System32\win32u.dll
ModLoad: 00007ffc`d1560000 00007ffc`d1620000   C:\Windows\System32\OLEAUT32.dll
ModLoad: 00007ffc`d0a60000 00007ffc`d0afc000   C:\Windows\System32\msvcp_win.dll
ModLoad: 00007ffc`d1930000 00007ffc`d1982000   C:\Windows\System32\SHLWAPI.dll
ModLoad: 00007ffc`cc4a0000 00007ffc`cc4aa000   C:\Windows\SYSTEM32\VERSION.dll
ModLoad: 00007ffc`cfc90000 00007ffc`cfcbb000   C:\Windows\SYSTEM32\bcrypt.dll
ModLoad: 00007ffc`d1290000 00007ffc`d12be000   C:\Windows\System32\IMM32.DLL
ModLoad: 00007ffc`a4a30000 00007ffc`a56bf000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\System.Private.CoreLib.dll
ModLoad: 00007ffc`ba180000 00007ffc`ba2cc000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\clrjit.dll
ModLoad: 00007ffc`d0100000 00007ffc`d010f000   C:\Windows\System32\kernel.appcore.dll
ModLoad: 000001fc`20a80000 000001fc`20a88000   C:\Training\Homework\NET.A.2019.Khotsin\NET.A.2019.Khotsin.20\UsingWinDbgAndSos\bin\Debug\netcoreapp2.2\UsingWinDbgAndSos.dll
ModLoad: 00007ffc`cbc70000 00007ffc`cbc7d000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\System.Runtime.dll
ModLoad: 00007ffc`ba4c0000 00007ffc`ba4e7000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\System.Console.dll
ModLoad: 00007ffc`bd5c0000 00007ffc`bd5d3000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\System.Threading.dll
ModLoad: 00007ffc`ba000000 00007ffc`ba060000   C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.2.6\System.Runtime.Extensions.dll
(24f8.398): Break instruction exception - code 80000003 (first chance)
ntdll!DbgBreakPoint:
00007ffc`d3cf9360 cc              int     3
```
Load SOS.dll extension:
```
.loadby sos coreclr
```
Get info about Employee class:
```
0:008> !name2ee UsingWinDbgAndSos UsingWinDbgAndSos.Employee
Module:      00007ffc45c045b0
Assembly:    UsingWinDbgAndSos.dll
Token:       0000000002000004
MethodTable: 00007ffc45c06700
EEClass:     00007ffc45da11e8
Name:        UsingWinDbgAndSos.Employee
```
Get info about method table of Employee class:
```
0:008> !dumpmt -md 00007ffc45c06700
EEClass:         00007ffc45da11e8
Module:          00007ffc45c045b0
Name:            UsingWinDbgAndSos.Employee
mdToken:         0000000002000004
File:            C:\Training\Homework\NET.A.2019.Khotsin\NET.A.2019.Khotsin.20\UsingWinDbgAndSos\bin\Debug\netcoreapp2.2\UsingWinDbgAndSos.dll
BaseSize:        0x20
ComponentSize:   0x0
Slots in VTable: 8
Number of IFaces in IFaceMap: 0
--------------------------------------
MethodDesc Table
           Entry       MethodDesc    JIT Name
00007ffc45d21070 00007ffc45c066d8   NONE UsingWinDbgAndSos.Employee.ToString()
00007ffca5086000 00007ffca4bd2bd0 PreJIT System.Object.Equals(System.Object)
00007ffca5086050 00007ffca4bd2bf8 PreJIT System.Object.GetHashCode()
00007ffca5086060 00007ffca4bd2c18 PreJIT System.Object.Finalize()
00007ffc45d21058 00007ffc45c066b0   NONE UsingWinDbgAndSos.Employee.Work()
00007ffc45d23190 00007ffc45c066e0    JIT UsingWinDbgAndSos.Employee..ctor()
00007ffc45d231e0 00007ffc45c066b8    JIT UsingWinDbgAndSos.Employee.TakeVacation(Int32)
00007ffc45d21a60 00007ffc45c066c8    JIT UsingWinDbgAndSos.Employee.SetCompanyPolicy(UsingWinDbgAndSos.CompanyPolicy)
```
Get info about EEClass of Employee class:
```
0:008> !dumpclass 00007ffc45da11e8
Class Name:      UsingWinDbgAndSos.Employee
mdToken:         0000000002000004
File:            C:\Training\Homework\NET.A.2019.Khotsin\NET.A.2019.Khotsin.20\UsingWinDbgAndSos\bin\Debug\netcoreapp2.2\UsingWinDbgAndSos.dll
Parent Class:    00007ffca4b2c780
Module:          00007ffc45c045b0
Method Table:    00007ffc45c06700
Vtable Slots:    5
Total Method Slots:  6
Class Attributes:    100001  
NumInstanceFields:   2
NumStaticFields:     1
              MT    Field   Offset                 Type VT     Attr            Value Name
00007ffca54828f0  4000001       10         System.Int32  1 instance           _id
00007ffca54806e8  4000002        8        System.String  0 instance           _name
00007ffc45c06918  4000003        8 ...Sos.CompanyPolicy  0   static 000001fc226541c0 _policy
```
Get info about Manager class:
```
0:008> !name2ee UsingWinDbgAndSos UsingWinDbgAndSos.Manager
Module:      00007ffc45c045b0
Assembly:    UsingWinDbgAndSos.dll
Token:       0000000002000005
MethodTable: 00007ffc45c06a08
EEClass:     00007ffc45da1430
Name:        UsingWinDbgAndSos.Manager
```
Get info about method table of Manager class:
```
0:008> !dumpmt -md 00007ffc45c06a08
EEClass:         00007ffc45da1430
Module:          00007ffc45c045b0
Name:            UsingWinDbgAndSos.Manager
mdToken:         0000000002000005
File:            C:\Training\Homework\NET.A.2019.Khotsin\NET.A.2019.Khotsin.20\UsingWinDbgAndSos\bin\Debug\netcoreapp2.2\UsingWinDbgAndSos.dll
BaseSize:        0x28
ComponentSize:   0x0
Slots in VTable: 7
Number of IFaces in IFaceMap: 1
--------------------------------------
MethodDesc Table
           Entry       MethodDesc    JIT Name
00007ffc45d232d0 00007ffc45c069d0    JIT UsingWinDbgAndSos.Manager.ToString()
00007ffca5086000 00007ffca4bd2bd0 PreJIT System.Object.Equals(System.Object)
00007ffca5086050 00007ffca4bd2bf8 PreJIT System.Object.GetHashCode()
00007ffca5086060 00007ffca4bd2c18 PreJIT System.Object.Finalize()
00007ffc45d23280 00007ffc45c069c8    JIT UsingWinDbgAndSos.Manager.Work()
00007ffc45d23330 00007ffc45c069c0    JIT UsingWinDbgAndSos.Manager.Manage()
00007ffc45d23230 00007ffc45c069d8    JIT UsingWinDbgAndSos.Manager..ctor()
```
Get info about EEClass of Manager class:
```
0:008> !dumpclass 00007ffc45da1430
Class Name:      UsingWinDbgAndSos.Manager
mdToken:         0000000002000005
File:            C:\Training\Homework\NET.A.2019.Khotsin\NET.A.2019.Khotsin.20\UsingWinDbgAndSos\bin\Debug\netcoreapp2.2\UsingWinDbgAndSos.dll
Parent Class:    00007ffc45da11e8
Module:          00007ffc45c045b0
Method Table:    00007ffc45c06a08
Vtable Slots:    6
Total Method Slots:  7
Class Attributes:    100001  
NumInstanceFields:   3
NumStaticFields:     0
              MT    Field   Offset                 Type VT     Attr            Value Name
00007ffca54828f0  4000001       10         System.Int32  1 instance           _id
00007ffca54806e8  4000002        8        System.String  0 instance           _name
00007ffc45c06918  4000003        8 ...Sos.CompanyPolicy  0   static 000001fc226541c0 _policy
0000000000000000  4000004       18                       0 instance           _reports
```
