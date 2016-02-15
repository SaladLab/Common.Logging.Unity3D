using System;
using UnityEngine;
using UnityEngine.UI;
using SampleLibrary;
using LumberjackClient;
using System.Collections.Generic;

public class MainScene : MonoBehaviour
{
    public Text LogText;

    private int _lastLogId;

    void OnEnable()
    {
        LogMemoryStorage.Instance.Install();
    }

    void OnDisable()
    {
        LogMemoryStorage.Instance.Uninstall();
        LogstashForwarder.Instance.Uninstall();
    }

    void Start()
    {
        Log("Welcome to Sample!");
    }

    void Log(string text)
    {
        LogText.text = LogText.text + text + "\n";
    }

    public void OnDebugLogButtonClick()
    {
        Log("OnDebugLogButtonClick");
        Debug.Log("DebugLog:" + DateTime.Now);
    }

    public void OnLibraryLogButtonClick()
    {
        Log("OnLibraryLogButtonClick");
        TestUtility.LogInfo("LibraryLog:" + DateTime.Now);
    }

    public void OnClearLogButtonClick()
    {
        LogText.text = "";
    }

    public void OnReportLogButtonClick()
    {
        var logs = LogMemoryStorage.Instance.GetLogs(ref _lastLogId);
        var count = (logs != null) ? logs.Count : 0;
        Log("# of SavedLog after last report: " + count);
    }

    public void OnLogstashButtonClick()
    {
        if (LogstashForwarder.Instance.Installed)
        {
            LogstashForwarder.Instance.Uninstall();
            Log("Logstash uninstalled.");
        }
        else
        {
            LogstashForwarder.Instance.ClientSettings = new LumberjackClientSettings
            {
                Host = "localhost",
                Port = 5000,
                SendConfirm = LumberjackClientSettings.SendConfirmPolicy.Receive,
                SendFull = LumberjackClientSettings.SendFullPolicy.Drop
            };
            LogstashForwarder.Instance.ParseFilterEnabled = true;
            LogstashForwarder.Instance.Fields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("app", "sample"),
                new KeyValuePair<string, string>("appversion", "1.0"),
                new KeyValuePair<string, string>("deviceid", SystemInfo.deviceUniqueIdentifier),
                new KeyValuePair<string, string>("devicemodel", SystemInfo.deviceModel)
            };
            LogstashForwarder.Instance.Install();
            Log("Logstash installed.");
        }
    }
}
