using Common.Logging.Factory;
using Common.Logging.Configuration;

namespace Common.Logging.Simple
{
    public class UnityDebugLoggerFactoryAdapter : AbstractCachingLoggerFactoryAdapter
    {
        private LogLevel _level;
        private bool _showLogName;
        private bool _showLogLevel;
        private bool _useUnityLogLevel;

        public UnityDebugLoggerFactoryAdapter()
        {
            _level = LogLevel.All;
            _showLogName = true;
            _showLogLevel = true;
            _useUnityLogLevel = true;
        }

        public UnityDebugLoggerFactoryAdapter(NameValueCollection properties)
        {
            _level = ArgUtils.TryParseEnum(LogLevel.All, ArgUtils.GetValue(properties, "level"));
            _showLogName = ArgUtils.TryParse(true, ArgUtils.GetValue(properties, "showLogName"));
            _showLogLevel = ArgUtils.TryParse(true, ArgUtils.GetValue(properties, "showLogLevel"));
            _useUnityLogLevel = ArgUtils.TryParse(true, ArgUtils.GetValue(properties, "useUnityLogLevel"));
        }

        public UnityDebugLoggerFactoryAdapter(LogLevel level, bool showLogName, bool showLogLevel, bool useUnityLogLevel)
        {
            _level = level;
            _showLogName = showLogName;
            _showLogLevel = showLogLevel;
            _useUnityLogLevel = useUnityLogLevel;
        }

        protected override ILog CreateLogger(string name)
        {
            return new UnityDebugLogger(name, _level, _showLogName, _showLogLevel, _useUnityLogLevel);
        }
    }
}
