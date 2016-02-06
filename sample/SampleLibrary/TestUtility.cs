using Common.Logging;

namespace SampleLibrary
{
    public static class TestUtility
    {
        private static ILog _log = LogManager.GetLogger("TestUtility");

        public static void LogDebug(string message)
        {
            _log.Debug("LogDebug:" + message);
        }

        public static void LogError(string message)
        {
            _log.Error("LogError:" + message);
        }

        public static void LogFatal(string message)
        {
            _log.Fatal("LogFatal:" + message);
        }

        public static void LogInfo(string message)
        {
            _log.Info("LogInfo:" + message);
        }

        public static void LogTrace(string message)
        {
            _log.Trace("LogTrace:" + message);
        }

        public static void LogWarn(string message)
        {
            _log.Warn("LogWarn:" + message);
        }
    }
}
