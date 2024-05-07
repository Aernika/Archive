using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private string logFilePath;

    void Awake()
    {
        // ��������� ���� � ����� ����
        logFilePath = Path.Combine(Application.persistentDataPath, "appLog.txt");

        // ������������� �� ������� �����������
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        // ����������� ���
        string logEntry = $"{System.DateTime.Now.ToLongTimeString()} {type}: {logString}\n";
        if (type == LogType.Exception || type == LogType.Error)
        {
            logEntry += $"StackTrace: {stackTrace}\n";
        }

        // ���������� ��� � ����
        File.AppendAllText(logFilePath, logEntry);
    }

    void OnDestroy()
    {
        // ������������ �� ������� ��� ����������� �������
        Application.logMessageReceived -= HandleLog;
    }
}
