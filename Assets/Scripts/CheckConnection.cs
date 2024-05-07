using UnityEngine.Networking;
using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class CheckConnection : MonoBehaviour
{
    public TMP_Text resultText; // ������� ��� � Text �� ����� ����� ����� ���������
    private string url = "http://95.188.79.124:8888/swagger"; // �������� URL �� ������ ��� �����

    private void Start()
    {
        StartCoroutine(CheckConnectionCoroutine());
    }

    IEnumerator CheckConnectionCoroutine()
    {
        while (true) // ����������� ���� ��� ������������� ��������
        {
            // ���������� ������
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                // ������� ���������� �������
                yield return webRequest.SendWebRequest();
                DateTime now = DateTime.Now;
                if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                    webRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    // � ������ ������ ������� ��������� � �������
                    resultText.text = $"{now.ToString("HH: mm: ss")}: ������ �����������: {webRequest.error}";
                }
                else
                {
                    // ��� �������� ����������� ������� ��������� �� ������
                    resultText.text = $"{now.ToString("HH: mm: ss")}: �������� �����������!";
                }
            }

            // ������� 5 ������ ����� ��������� ��������
            yield return new WaitForSeconds(10f);
        }
    }
}
