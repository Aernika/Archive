using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonFilters : MonoBehaviour
{
    public GameObject btnPrefab;
    public GameObject btnLayout2;
    public GameObject scrollView;
    public bool status; //true = 1, false = 2
    
    public void StartCreate(List<String> btnT)
    {
        if (status)
        {
            DeleteAllChildren(this.gameObject);
            DeleteAllChildren(btnLayout2);
            scrollView.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(0, -138);
        }
        else
        {
            scrollView.GetComponent<RectTransform>().anchoredPosition = 
                new Vector2(0, -202);
        }
        CreateFilterBtn(btnT);
    }
    void DeleteAllChildren(GameObject parent)
    {
        int childCount = parent.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = parent.transform.GetChild(i);
            Destroy(child.gameObject);
        }
    }
    void CreateFilterBtn(List<String> btnTexts)
    {
        int len = 0;
        int nmbStop = -1;
        for (int i = 0; i < btnTexts.Count; i++)
        {
            len += (btnTexts[i].Length)*17;
            len += 45;
            if (len < 1650)
            {
                GameObject newButton = Instantiate(btnPrefab, this.transform);
                TMP_Text buttonTextComponent = newButton.GetComponentInChildren<TMP_Text>();
                buttonTextComponent.text = btnTexts[i];
                newButton.GetComponent<RectTransform>().sizeDelta = 
                    new Vector2(buttonTextComponent.GetPreferredValues().x, 50f);
            }
            else
            {
                nmbStop = i;
                break;
            }
        }

        if (nmbStop != -1 && status)
        {
            //Debug.Log(nmbStop);
            btnTexts.RemoveRange(0, nmbStop);
            btnLayout2.GetComponent<ButtonFilters>().StartCreate(btnTexts);
        }
    }
}
