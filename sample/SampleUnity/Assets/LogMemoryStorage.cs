using System;
using System.Collections.Generic;
using UnityEngine;

public class LogMemoryStorage
{
    private static LogMemoryStorage _instance;

    public static LogMemoryStorage Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LogMemoryStorage();
            return _instance;
        }
    }

    public class LogEntity
    {
        public int Id;
        public DateTime Time;
        public string Condition;
        public string StackTrace;
        public LogType Type;
    }

    private bool _installed;
    private int _lastLogId;
    private int _maxLogCount;
    private List<LogEntity> _logs = new List<LogEntity>();

    public bool Installed
    {
        get { return _installed; }
    }

    public int LastLogId
    {
        get { return _lastLogId; }
    }

    public int MaxLogCount
    {
        get { return _maxLogCount; }
        set { _maxLogCount = value; }
    }

    public LogMemoryStorage(int maxLogCount = 0)
    {
        _maxLogCount = maxLogCount;
    }

    public void Install()
    {
        if (_installed)
            return;

        _installed = true;
        Application.logMessageReceivedThreaded += OnLogMessageReceive;
    }

    public void Uninstall()
    {
        if (_installed == false)
            return;

        _installed = false;
        Application.logMessageReceivedThreaded -= OnLogMessageReceive;
    }

    public List<LogEntity> GetLogs(ref int baseLogId)
    {
        lock (_logs)
        {
            if (_logs.Count == 0)
                return null;

            var lastLogId = _logs[_logs.Count - 1].Id;
            var newLogCount = lastLogId - baseLogId;
            if (newLogCount <= 0)
                return null;

            baseLogId = lastLogId;
            var count = Math.Min(_logs.Count, newLogCount);
            return _logs.GetRange(_logs.Count - count, count);
        }
    }

    private void OnLogMessageReceive(string condition, string stacktrace, LogType type)
    {
        lock (_logs)
        {
            _lastLogId += 1;
            _logs.Add(new LogEntity
            {
                Id = _lastLogId,
                Time = DateTime.Now,
                Condition = condition,
                StackTrace = stacktrace,
                Type = type
            });

            if (_maxLogCount > 0)
            {
                var removeCount = _logs.Count - _maxLogCount;
                if (removeCount > 0)
                    _logs.RemoveRange(0, removeCount);
            }
        }
    }
}
