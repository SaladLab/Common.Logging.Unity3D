using UnityEngine;
using UnityEngine.UI;
using SampleLibrary;
using System;

public class MainScene : MonoBehaviour
{
    public Text LogText;

    private int _lastLogId;

    void Start()
    {
        LogMemoryStorage.Instance.Install();
        Log("Welcome to Sample");
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
}
