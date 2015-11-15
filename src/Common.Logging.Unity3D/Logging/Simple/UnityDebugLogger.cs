using Common.Logging.Factory;
using System;
using System.Text;

namespace Common.Logging.Simple
{
    public class UnityDebugLogger : AbstractLogger
    {
        private readonly string _name;
        private LogLevel _logLevel;
        private bool _showLogName;
        private bool _showLogLevel;
        private bool _useUnityLogLevel;

        public UnityDebugLogger(string name, LogLevel logLevel, 
                                bool showLogName, bool showLogLevel, bool useUnityLogLevel)
        {
            _name = name;
            _logLevel = logLevel;
            _showLogName = showLogName;
            _showLogLevel = showLogLevel;
            _useUnityLogLevel = useUnityLogLevel;
        }

        public string Name
        {
            get { return _name; }
        }

        public LogLevel CurrentLogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }

        public bool ShowLogName
        {
            get { return _showLogName; }
            set { _showLogName = value; }
        }

        public bool ShowLogLevel
        {
            get { return _showLogLevel; }
            set { _showLogLevel = value; }
        }

        public bool UseUnityLogLevel
        {
            get { return _useUnityLogLevel; }
            set { _useUnityLogLevel = value; }
        }

        private bool IsLevelEnabled(LogLevel level)
        {
            int iLevel = (int)level;
            int iCurrentLogLevel = (int)_logLevel;

            return (iLevel >= iCurrentLogLevel);
        }

        public override bool IsTraceEnabled
        {
            get { return IsLevelEnabled(LogLevel.Trace); }
        }

        public override bool IsDebugEnabled
        {
            get { return IsLevelEnabled(LogLevel.Debug); }
        }

        public override bool IsInfoEnabled
        {
            get { return IsLevelEnabled(LogLevel.Info); }
        }

        public override bool IsWarnEnabled
        {
            get { return IsLevelEnabled(LogLevel.Warn); }
        }

        public override bool IsErrorEnabled
        {
            get { return IsLevelEnabled(LogLevel.Error); }
        }

        public override bool IsFatalEnabled
        {
            get { return IsLevelEnabled(LogLevel.Fatal); }
        }

        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            var sb = new StringBuilder();

            if (_showLogName)
                sb.Append("[<b>" + Name + "</b>] ");

            if (_showLogLevel)
                sb.Append(GetLogLevelString(level) + " ");

            sb.Append(message);
            if (exception != null)
                sb.Append("\n" + exception);

            if (_useUnityLogLevel)
            {
                if (level < LogLevel.Warn)
                    UnityEngine.Debug.Log(sb.ToString());
                else if (level == LogLevel.Warn)
                    UnityEngine.Debug.LogWarning(sb.ToString());
                else if (level >= LogLevel.Error)
                    UnityEngine.Debug.LogError(sb.ToString());
            }
            else
            {
                UnityEngine.Debug.Log(sb.ToString());
            }
        }

        private string GetLogLevelString(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return "<color=grey>(Trace)</color>";
                case LogLevel.Debug:
                    return "<color=grey>(Debug)</color>";
                case LogLevel.Info:
                    return "<color=white>(Info)</color>";
                case LogLevel.Warn:
                    return "<color=orange>(Warn)</color>";
                case LogLevel.Error:
                    return "<color=red>(Error)</color>";
                case LogLevel.Fatal:
                    return "<color=red>(Fatal)</color>";
                default:
                    return level.ToString();
            }
        }
    }
}
