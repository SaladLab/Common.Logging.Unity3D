using UnityEngine;
using Common.Logging;

public class CommonLoggingSample : MonoBehaviour
{
    private ILog _log = LogManager.GetLogger("Sample");

    void Start()
    {
        _log.Debug("Debug Log");
        _log.Info("Info Log");
        _log.Warn("Warn Log");
        _log.Error("Error Log");
    }
}
