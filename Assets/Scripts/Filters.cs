using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Image = UnityEngine.UI.Image;

public class Filters : MonoBehaviour
{
    public Sprite blackBtn;
    public Sprite blueBtn;
    public bool status; //false = black, true = blue
    public GameObject filterController;
    public GameObject cardCreator;
    public GameObject controller;
    public void Start()
    {
        status = false;
    }

    public void BtnClickFilter()
    {
        status = !status;
        if (status)
        {
            this.GetComponent<Image>().sprite = blueBtn;
            this.GetComponent<Image>().pixelsPerUnitMultiplier = 10f; 
            this.GetComponentInChildren<TMP_Text>().color = Color.white;
            string text = gameObject.GetComponentInChildren<TMP_Text>().text;
            filterController.GetComponent<ButtonFilters>().filtersTitles.Add(text);
        }
        else
        {
            this.GetComponent<Image>().sprite = blackBtn;
            this.GetComponent<Image>().pixelsPerUnitMultiplier = 4.09f;
            this.GetComponentInChildren<TMP_Text>().color = Color.black;
            string text = gameObject.GetComponentInChildren<TMP_Text>().text;
            int id = -1;
            for (int i = 0; i < filterController.GetComponent<ButtonFilters>().filtersTitles.Count; i++)
            {
                if (filterController.GetComponent<ButtonFilters>().filtersTitles[i] == text) 
                {
                    id = i;
                    break;
                }
            }
            filterController.GetComponent<ButtonFilters>().filtersTitles.RemoveAt(id);
        }
        cardCreator.GetComponent<Cards>().StartCreate(controller.GetComponent<MainMenu>().numCategory, filterController.GetComponent<ButtonFilters>().filtersTitles);
        cardCreator.GetComponent<Cards>().StartCreate(controller.GetComponent<MainMenu>().numCategory, filterController.GetComponent<ButtonFilters>().filtersTitles);
    }
}
