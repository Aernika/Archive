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
    public GameObject archive;
    public GameObject content;
    public GameObject contentGallery;

    public void StartCreate(int indexCategory, List<string> filters=null)
    {
        ButtonFilters.DeleteAllChildren(gameObject);
        CreateContentCard(archive.GetComponent<ArсhiveContent>().categories[indexCategory].cardsobj, indexCategory, filters);
    }
    void CreateContentCard(List<ArсhiveContent.Card> cards, int index, List<string> filters=null)
    {
        if (filters is null) filters = new List<string>();
        foreach (ArсhiveContent.Card card in cards)
        {
            if (filters.Count > 0)
            {
                foreach (string str in filters)
                {
                    if (str == card.tag)
                    {
                        GameObject newCard = Instantiate(cardPrefab, gameObject.transform);
                        Button btn = newCard.GetComponent<Button>();
                        btn.onClick.AddListener(newCard.GetComponent<ClickCard>().ClickOnCard);

                        newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().text = card.tag;
                        newCard.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                            new Vector2(
                                newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                                35f);
                        newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        if (card.idposter != 0) newCard.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = 
                            archive.GetComponent<ArсhiveContent>().GetImage(card.idposter);
                        else newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        newCard.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>().text = card.title; 
                        newCard.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = card.shortdescription;
            
                        newCard.GetComponent<ClickCard>().indexCategory = index;
                        newCard.GetComponent<ClickCard>().thisCard = card;
                        newCard.GetComponent<ClickCard>().archive = archive;
                        newCard.GetComponent<ClickCard>().controller = controller;
                        newCard.GetComponent<ClickCard>().content = content;
                        newCard.GetComponent<ClickCard>().contentGallery = contentGallery;
                    }
                }
            }
            else 
            {
                GameObject newCard = Instantiate(cardPrefab, gameObject.transform);
                Button btn = newCard.GetComponent<Button>();
                btn.onClick.AddListener(newCard.GetComponent<ClickCard>().ClickOnCard);
            
                newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().text = card.tag;
                newCard.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(
                        newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                        35f);
                newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                if (card.idposter != 0) newCard.transform.GetChild(1).gameObject.GetComponentInChildren<Image>().sprite = 
                    archive.GetComponent<ArсhiveContent>().GetImage(card.idposter);
                else newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                newCard.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>().text = card.title; 
                newCard.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = card.shortdescription;
            
                newCard.GetComponent<ClickCard>().indexCategory = index;
                newCard.GetComponent<ClickCard>().thisCard = card;
                newCard.GetComponent<ClickCard>().archive = archive;
                newCard.GetComponent<ClickCard>().controller = controller;
                newCard.GetComponent<ClickCard>().content = content;
                newCard.GetComponent<ClickCard>().contentGallery = contentGallery;
            }
        }
    }
}
