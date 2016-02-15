using System;
using System.Collections.Generic;
using UnityEngine;

public class LogstashForwarder
{
    private static LogstashForwarder _instance;

    public static LogstashForwarder Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LogstashForwarder();
            return _instance;
        }
    }

    private bool _installed;
    private LumberjackClient.LumberjackClient _client;
    private LumberjackClient.LumberjackClientSettings _clientSettings;

    public bool Installed
    {
        get { return _installed; }
    }

    public LumberjackClient.LumberjackClientSettings ClientSettings
    {
        get { return _clientSettings; }
        set { _clientSettings = value; }
    }

    public bool ParseFilterEnabled { get; set; }
    public List<KeyValuePair<string, string>> Fields { get; set; }

    public LogstashForwarder(LumberjackClient.LumberjackClientSettings clientSettings = null)
    {
        _clientSettings = clientSettings;
    }

    public void Install()
    {
        if (_installed)
            return;

        _installed = true;
        _client = new LumberjackClient.LumberjackClient(_clientSettings);
        Application.logMessageReceivedThreaded += OnLogMessageReceive;
    }

    public void Uninstall()
    {
        if (_installed == false)
            return;

        _installed = false;
        _client.Close();
        _client = null;
        Application.logMessageReceivedThreaded -= OnLogMessageReceive;
    }

    private void OnLogMessageReceive(string condition, string stacktrace, LogType type)
    {
        if (ParseFilterEnabled == false)
        {
            var kvs = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("@timestamp", DateTime.UtcNow.ToString("o")),
                new KeyValuePair<string, string>("level", type.ToString()),
                new KeyValuePair<string, string>("message", condition),
                new KeyValuePair<string, string>("stacktrace", stacktrace)
            };

            if (Fields != null)
                kvs.AddRange(Fields);

            _client.Send(kvs);
        }
        else
        {
            string loggerName, logLevel, message, exception;
            ParseLogInfo(condition, type, out loggerName, out logLevel, out message, out exception);

            var kvs = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("@timestamp", DateTime.UtcNow.ToString("o")),
                new KeyValuePair<string, string>("logger", loggerName),
                new KeyValuePair<string, string>("level", logLevel),
                new KeyValuePair<string, string>("message", message),
                new KeyValuePair<string, string>("stacktrace", stacktrace)
            };

            if (exception != null)
                kvs.Add(new KeyValuePair<string, string>("exception", exception));

            if (Fields != null)
                kvs.AddRange(Fields);

            _client.Send(kvs);
        }
    }

    private void ParseLogInfo(string condition, LogType type, 
                              out string loggerName, out string logLevel, out string message, out string exception)
    {
        // parse [<b>LoggerName</b>] <color=white>(LogLevel)</color> Message <Exception>:Exception

        if (condition.StartsWith("["))
        {
            var i = condition.IndexOf("] ", 1);
            if (i != -1)
            {
                var j = condition.IndexOf(' ', i + 2);
                if (j != -1)
                {
                    loggerName = ParseLoggerName(condition.Substring(1, i - 1));
                    logLevel = ParseLogLevel(condition.Substring(i + 1, j - i));
                    message = condition.Substring(j + 1);
                    exception = null;
                    return;
                }
            }
        }

        // fallback

        loggerName = "Unity";
        switch (type)
        {
            case LogType.Error:
                logLevel = "Error";
                break;
            case LogType.Assert:
                logLevel = "Error";
                break;
            case LogType.Warning:
                logLevel = "Warn";
                break;
            case LogType.Log:
                logLevel = "Info";
                break;
            case LogType.Exception:
                logLevel = "Error";
                break;
            default:
                logLevel = "";
                break;
        }

        message = condition;
        exception = null;
    }

    private string ParseLoggerName(string s)
    {
        // LoggerName | <b>LoggerName</b>

        if (s.StartsWith("<") && s.Length > 7)
            return s.Substring(3, s.Length - 7);
        return s;
    }

    private string ParseLogLevel(string s)
    {
        // (LogLevel) | <color=...>(LogLevel)</color>

        var i = s.IndexOf('(');
        if (i == -1)
            return s;

        var j = s.IndexOf(')', i + 1);
        if (j == -1)
            return s;

        return s.Substring(i + 1, j - i - 1);
    }
}
