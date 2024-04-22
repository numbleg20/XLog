# XLog (.NET Framework)
A simple logger with recording to a file and output to the console

# Documentation
1.To use it you will need to add a XLog.dll to your project.<br>
`Right-click on "links" in your project > "Add link" > "Browse" and specify the XLog.dll file.`<br><br>

2.Add ```using XLog;``` to the header.<br><br>

3.In the area where you want to track logging, enter this code:

```C#
Logger mainLogger = new Logger();

mainLogger.Log(LogType.DEBUG, "Debug message");

```

In details:

```C#
Logger mainLogger = new Logger();

mainLogger.Log(
    logType: LogType.DEBUG, 
    logText: "Debug message");

```

logType - this is a constant value that you can take by calling the LogType command.

List of available types:
```C#
LogType.DEBUG
LogType.WARNING
LogType.INFO
LogType.ERROR
```

logText - this is the text for logging.<br>

By default, XLog creates a `log.xlog` file at `path_to_your_program/logs`, but you can specify your own path and file name with this line:
```C#
mainLogger.logFilePath = "your_path/logFileName";
```
