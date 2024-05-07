using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startTouchPosition;
    private Vector2 currentSwipe;

    public float minSwipeLength = 100f; // ����������� ����� ������ ��� �������

    // ������� ��� �������
    public event System.Action OnSwipeLeft;
    public event System.Action OnSwipeRight;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startTouchPosition = eventData.position; // ���������� ��������� ��������� ��� ������ ������
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ����� ����� �������� ���, ���� ����� ������������ ���-�� �� ����� ��������
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        currentSwipe = eventData.position - startTouchPosition; // ������ ������� ������
        ProcessSwipe();
    }

    private void ProcessSwipe()
    {
        if (currentSwipe.magnitude < minSwipeLength)
        {
            return; // ���� ����� ������ ������ �����������, ���������� ���
        }

        currentSwipe.Normalize();

        // �������� ����������� ������ (��������������)
        if (Mathf.Abs(currentSwipe.x) > Mathf.Abs(currentSwipe.y))
        {
            if (currentSwipe.x > 0)
            {
                OnSwipeRight?.Invoke(); // ����� ������
            }
            else
            {
                OnSwipeLeft?.Invoke(); // ����� �����
            }
        }
    }
}
