using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadingIndicator : MonoBehaviour
{
    private List<UnityWebRequest> activeRequests = new List<UnityWebRequest>();
    public int activeTasks = 0;
    void Awake()
    {
        Hide();  // ���������� ������ ������
    }
    public void Show()
    {
        gameObject.GetComponent<Image>().enabled = true;
        //this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.GetComponent<Image>().enabled = false;
        //this.gameObject.SetActive(false);
    }
    public void AddRequest(UnityWebRequest request) // ���������� ������� � ������ ��������
    {
        activeTasks++;
        Show();
        activeRequests.Add(request);
        //StartCoroutine(HandleRequest(request));
    }
    public IEnumerator HandleRequest(UnityWebRequest request) // ��������� �������
    {
        yield return request.SendWebRequest();
        activeRequests.Remove(request);
        TaskCompleted();
    }
    public void TaskCompleted() // ��������, ��� �� ������� ���������
    {
        activeTasks--;
        if (activeTasks == 0)
        {
            Debug.Log("��� ������� ���������");
            Hide();
        }
    }
    public void AddTask(IEnumerator taskRoutine)
    {
        activeTasks++;  // ����������� ������� �������� �����
        Show();
        StartCoroutine(HandleCustomTask(taskRoutine));
    }

    // ��������� ���������������� �����
    private IEnumerator HandleCustomTask(IEnumerator taskRoutine)
    {
        yield return StartCoroutine(taskRoutine);
        TaskCompleted();
    }
}
