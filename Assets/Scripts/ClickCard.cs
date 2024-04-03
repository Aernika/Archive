using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickCard : MonoBehaviour
{
    public int indexCategory;
    public ArсhiveContent.Card thisCard;
    public GameObject content;
    public GameObject controller;
    public GameObject archive;
    public GameObject contentGallery;

    public void GalleryBtn()
    {
        //contentGallery.GetComponent<Galery>().thisCard = thisCard;
        controller.GetComponent<MainMenu>().CLickPhotos();
        List<int> l1 = thisCard.photos;
        List<int> l2 = thisCard.videos;
        contentGallery.GetComponent<Galery>().ClickGalery(l1, l2);
    }
    
    public void ClickOnCard()
    {
        controller.GetComponent<MainMenu>().level = 3;
        content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(this.GetComponent<ClickCard>().GalleryBtn);


        if (indexCategory == 1 || indexCategory == 2) // театр и кино
        {
            content.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
            if (thisCard.idposter != 0)
            {
                content.transform.GetChild(0).gameObject.SetActive(true);
                content.transform.GetChild(0).GetComponent<Image>().sprite =
                    archive.GetComponent<ArсhiveContent>().GetImage(thisCard.idposter);
            }
            else content.transform.GetChild(0).gameObject.SetActive(false);
            //controller.GetComponent<MainMenu>().Title.text = thisCard.title;
            content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().text = thisCard.tag;
            content.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                    35f);
            content.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = thisCard.title;
            content.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = thisCard.shortdescription;
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = thisCard.description;
            content.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.SetActive(false);

            String tmp = "";
            for (int i = 0; i < thisCard.about.Count-2; i+=2)
            {
                tmp += thisCard.about[i] + "\t\t\t" + thisCard.about[i + 1] + "\n";
            }
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = tmp;
            
            if(thisCard.photos is null || thisCard.videos.Count < 1)  content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            else content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if(thisCard.videos is null || thisCard.videos.Count > 1)  content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            else content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (indexCategory == 0) //Музыка
        {
            content.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.UpperLeft;
            if (thisCard.idposter != 0)
            {
                content.transform.GetChild(0).gameObject.SetActive(true);
                content.transform.GetChild(0).GetComponent<Image>().sprite =
                    archive.GetComponent<ArсhiveContent>().GetImage(thisCard.idposter);
            }
            else content.transform.GetChild(0).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().text = thisCard.tag;
            content.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                    35f);
            content.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = thisCard.title;
            content.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = thisCard.shortdescription;
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = thisCard.description;
            content.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            
            String tmp = "";
            for (int i = 0; i < thisCard.about.Count-2; i+=2)
            {
                tmp += thisCard.about[i] + "\t\t\t" + thisCard.about[i + 1] + "\n";
            }
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = tmp;
            content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
            if(thisCard.photos is null || thisCard.videos.Count < 1)  content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            else content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            if(thisCard.videos is null || thisCard.videos.Count > 1)  content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            else content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            
        }
        else if (indexCategory == 3 || indexCategory == 4) //Литература и Путешествия
        {
            content.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.UpperLeft;
            if (thisCard.idposter != 0)
            {
                content.transform.GetChild(0).gameObject.SetActive(true);
                content.transform.GetChild(0).GetComponent<Image>().sprite =
                    archive.GetComponent<ArсhiveContent>().GetImage(thisCard.idposter);
            }
            else content.transform.GetChild(0).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().text = thisCard.tag;
            content.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    content.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponentInChildren<TMP_Text>().GetPreferredValues().x,
                    35f);
            content.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<TMP_Text>().text = thisCard.title;
            content.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = thisCard.shortdescription;
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).GetComponent<TMP_Text>().text = thisCard.text;
            content.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
            /*
            if (thisCard.photos is null && thisCard.videos.Count <= 1)
            {
                content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                content.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).GetComponent<RectTransform>().sizeDelta = new Vector2(1528f, 555f);
            }
            else
            {
                content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }*/
            content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            content.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    
}
