using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class Facts : MonoBehaviour
{
    public List<String> factsList;
    public GameObject firstFact;
    public GameObject secondFact;
    public GameObject thirdFact;
    public GameObject sliderBox;
    public GameObject prefabSlider;
    public Sprite blueSprite;
    public Sprite graySprite;
    public int status;
    void Start()
    {
        status = 0;
        firstFact.SetActive(false);
        secondFact.SetActive(false);
        thirdFact.SetActive(false);
    }

    public void CreateFacts()
    {
        ButtonFilters.DeleteAllChildren(sliderBox);
        for(int i = 0; i < factsList.Count; i ++)
        {
            GameObject newSlider = Instantiate(prefabSlider, sliderBox.transform);
            if (i == 0)
            {
                secondFact.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (i+1).ToString();
                secondFact.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = factsList[i];
                newSlider.GetComponent<Image>().sprite = blueSprite;
                secondFact.SetActive(true);
            }
            if (i == 1)
            {
                thirdFact.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (i+1).ToString();
                thirdFact.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = factsList[i];
                thirdFact.SetActive(true);
            }
        }
    }

    public void ClickRight()
    {
        SwitchFacts(true);
    }
    
    public void ClickLeft()
    {
        SwitchFacts(false);
    }
    
    public void SwitchFacts(bool right)
    {
        
        
        if (right)
        {
            if (status < factsList.Count - 1)
            {
                sliderBox.transform.GetChild(status).GetComponent<Image>().sprite = graySprite;
                status += 1;
            }
            else return;
        }
        else
        {
            if (0 < status)
            {
                sliderBox.transform.GetChild(status).GetComponent<Image>().sprite = graySprite;
                status -= 1;
            }
            else return;
        }
        sliderBox.transform.GetChild(status).GetComponent<Image>().sprite = blueSprite;

        if (status > 0)
        {
            firstFact.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (status).ToString();
            firstFact.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = factsList[status-1];
            firstFact.SetActive(true);
        }
        else firstFact.SetActive(false);
        
        secondFact.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (status+1).ToString();
        secondFact.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = factsList[status];

        if (status + 1 <= factsList.Count - 1)
        {
            thirdFact.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = (status+2).ToString();
            thirdFact.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = factsList[status+1];
            thirdFact.SetActive(true);
        }
        else thirdFact.SetActive(false);
    }
}
