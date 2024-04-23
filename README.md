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

<br>

**Add-ons and customization:**<br>

1.By default, XLog creates a `log.xlog` file at `path_to_your_program/logs`, but you can specify your own path and file name with this line:
```C#
mainLogger.logFilePath = "your_path/logFileName";
```

2.You can also change the formatting of the current hour and date:
```C#
mainLogger.logTimeFormat = "HH:mm:ss";
```
Formatting table : https://www.tutorialsteacher.com/articles/datetime-formats-in-csharp

3.You can change the colors of the logs:

```C#
mainLogger.colors[LogType.ERROR] = ConsoleColor.Green;
```

4.You can change text format for logs:

```C#
mainLogger.logTextFormat = "{0}, {1}, {2}";

Output:
    2024-04-23 14:50:06, ERROR, Error message
```
Elements (**THEY ARE MANDATORY**):<br>
**{0}** - date element<br>
**{1}** - logType element<br>
**{2}** - logText element<br>
