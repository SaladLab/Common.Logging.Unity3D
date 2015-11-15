using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Common.Logging;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Common.Logging for Unity3D")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Saladbowl Creative")]
[assembly: AssemblyProduct("Common Logging Framework")]
[assembly: AssemblyCopyright("Copyright © Saladbowl Creative 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("54147137-c9b2-4090-8d79-025082ebead9")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("3.3.1.0")]
[assembly: AssemblyFileVersion("3.3.1.0")]

[assembly: System.Security.SecurityTransparent]
[assembly: TypeForwardedTo(typeof(FormatMessageHandler))]
[assembly: TypeForwardedTo(typeof(IConfigurationReader))]
[assembly: TypeForwardedTo(typeof(ILog))]
[assembly: TypeForwardedTo(typeof(ILoggerFactoryAdapter))]
[assembly: TypeForwardedTo(typeof(ILogManager))]
[assembly: TypeForwardedTo(typeof(IVariablesContext))]
[assembly: TypeForwardedTo(typeof(LogLevel))]
