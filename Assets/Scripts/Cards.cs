using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject controller;
    public Sprite sprite1;
    public Sprite sprite2;
    
    public void StartCreate(List<List<String>> cardsT)
    {
        DeleteAllChildren(this.gameObject);
        CreateContentCard(cardsT);
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
    void CreateContentCard(List<List<String>> cardsT)
    {
        for (int i = 0; i < cardsT.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, this.gameObject.transform);
            Button btn = newCard.GetComponent<Button>();
            btn.onClick.AddListener(controller.GetComponent<MainMenu>().CLickContent);
            
            newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().text = cardsT[i][0];
            newCard.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                    35f);
        
            if (cardsT[i][1] == "0")
            {
                newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (cardsT[i][1] == "1")
            {
                newCard.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = sprite1; 
                newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (cardsT[i][1] == "2")
            {
                newCard.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = sprite2; 
                newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            
            newCard.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>().text = cardsT[i][2]; 
            newCard.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = cardsT[i][3];
        }
    }
}
