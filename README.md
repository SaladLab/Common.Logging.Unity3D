# Common Logging for Unity3D

[Common.Logging.NET](https://github.com/net-commons/common-logging) is a simple and
easy-to-use log adapter library supporting log4net, NLog and Enterprise library logging.
With this, it's quite easy to switch log system from one to another without rewriting code.
This library is for Unity3D and you can use Common.Logging.NET in Unity3D.

## Where can I get it?

Visit [Release](https://github.com/SaladLab/Common.Logging.Unity3D/releases)
page to get latest Common Logging for Unity3D unity-package.

## What's the deal?

Well-known log libraries support various .NET Framework and provides lots of logger
like file, memory, email and other many extensions.
But this is neither necessary nor ideal for common Unity3D apps (especially mobile).
because it's really important to keep size of app small.

If you want to use log feature in Unity3D. It's simple. You can use [Debug.Log](http://docs.unity3d.com/ScriptReference/Debug.Log.html) like this.

```csharp
void Example() {
    Debug.Log("Hello");
    Debug.Log("World");
}
```

Ok but what if you write a library to support both regular .NET Framework and Unity3D?
We can solve this problem like this using ```#if``` directive.

```csharp
void Example() {
#if UNITY3D  
    Debug.Log("Hello");
    Debug.Log("World");
#else    
    _log.Info("Hello"); // _log is an instance of ILog
    _log.Info("World");
#endif
}
```

But with Common.Logging you can simple write code like this.

```csharp
void Example() {
    _log.Info("Hello"); // _log is an instance of ILog
    _log.Info("World");
}
```

In regular .NET Framework you can use any log library that you want to use and
in Unity3D it will redirect all log messages to ```Debug.Log``` as you expect.
