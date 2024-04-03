using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.IO;
using System.Net.Mime;

public class MainMenu : MonoBehaviour
{
    public GameObject MainContent;
    public GameObject PanelTop;
    public GameObject ScrollView;
    public GameObject Object;
    public GameObject btnLayout1;
    public GameObject btnLayout2;
    public GameObject CardContentObject;
    public GameObject MediaPlayer;
    public GameObject Photos;
    public GameObject Facts;
    public GameObject btnbck;
    public GameObject titleT;
    public GameObject btnAbout;
    public GameObject archive;

    public int numCategory;
    public int level;
    private int levelOld;
    public string title;
    public TMP_Text Title;
    public TMP_Text Description;


    #region œË‚‡ÚÌ˚Â ÏÂÚÓ‰˚
    void Start()
    {
        level = levelOld = 1;
        ChangeCategory(level);
        numCategory = -1;
    }
    
    void Update()
    {
        if (levelOld != level)
        {
            ChangeCategory(level);
        }
    }
    void ChangeCategory(int lv)
    {
        if(lv == 1)
        {
            MainContent.SetActive(true);
            PanelTop.SetActive(false);
            ScrollView.SetActive(false);
            Object.SetActive(false);
            Title.gameObject.SetActive(true);
            Description.gameObject.SetActive(true);
            btnLayout1.SetActive(true);
            btnLayout2.SetActive(true);
            levelOld = 1;
        }
        else if (lv == 2)
        {
            MainContent.SetActive(false);
            PanelTop.SetActive(true);
            ScrollView.SetActive(true);
            Object.SetActive(false);
            Title.gameObject.SetActive(true);
            Description.gameObject.SetActive(true);
            btnLayout1.SetActive(true);
            btnLayout2.SetActive(true);
            levelOld = 2;
        }
        else if (lv == 3)
        {
            PanelTop.SetActive(true);
            ScrollView.SetActive(false);
            Object.SetActive(true);
            Title.gameObject.SetActive(false);
            Description.gameObject.SetActive(false);
            btnLayout1.SetActive(false);
            btnLayout2.SetActive(false);
            MediaPlayer.SetActive(false);
            Photos.SetActive(false);
            Facts.SetActive(false);
            btnbck.transform.GetChild(0).gameObject.SetActive(false);
            btnbck.transform.GetChild(1).gameObject.SetActive(true);
            btnbck.transform.GetChild(2).gameObject.SetActive(false);
            btnbck.transform.GetChild(3).gameObject.SetActive(true);
            btnbck.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().color = Color.black;
            titleT.SetActive(true);
            if (!btnAbout.GetComponent<AboutButtons>().status) btnAbout.GetComponent<AboutButtons>().BtnAboutClick();
            levelOld = 3;
        }
        else if (lv == 4)
        {
            PanelTop.SetActive(true);
            ScrollView.SetActive(false);
            Object.SetActive(false);
            Title.gameObject.SetActive(false);
            Description.gameObject.SetActive(false);
            btnLayout1.SetActive(false);
            btnLayout2.SetActive(false);
            levelOld = 4;
        }
    }
    #endregion

    #region  ÌÓÔÍË  ‡ÚÂ„ÓËÈ
    public void BtnCategory1()
    {
        Title.text = title = archive.GetComponent<ArÒhiveContent>().categories[0].title;
        Description.text =  archive.GetComponent<ArÒhiveContent>().categories[0].description;
        CardContentObject.GetComponent<Cards>().StartCreate(0);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(archive.GetComponent<ArÒhiveContent>().categories[0].filters);
        numCategory = 0;
        level = 2;
    }
    public void BtnCategory2()
    {
        Title.text = title = archive.GetComponent<ArÒhiveContent>().categories[1].title;
        Description.text =  archive.GetComponent<ArÒhiveContent>().categories[1].description;
        CardContentObject.GetComponent<Cards>().StartCreate(1);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(archive.GetComponent<ArÒhiveContent>().categories[1].filters);
        numCategory = 1;
        level = 2;
    }
    public void BtnCategory3()
    {
        Title.text = title = archive.GetComponent<ArÒhiveContent>().categories[2].title;
        Description.text =  archive.GetComponent<ArÒhiveContent>().categories[2].description;
        CardContentObject.GetComponent<Cards>().StartCreate(2);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(archive.GetComponent<ArÒhiveContent>().categories[2].filters);
        numCategory = 2;
        level = 2;
    }
    public void BtnCategory4()
    {
        Title.text = title = archive.GetComponent<ArÒhiveContent>().categories[3].title;
        Description.text =  archive.GetComponent<ArÒhiveContent>().categories[3].description;
        CardContentObject.GetComponent<Cards>().StartCreate(3);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(archive.GetComponent<ArÒhiveContent>().categories[3].filters);
        numCategory = 3;
        level = 2;
    }
    public void BtnCategory5()
    {
        Title.text = title = archive.GetComponent<ArÒhiveContent>().categories[4].title;
        Description.text =  archive.GetComponent<ArÒhiveContent>().categories[4].description;
        CardContentObject.GetComponent<Cards>().StartCreate(4);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(archive.GetComponent<ArÒhiveContent>().categories[4].filters);
        numCategory = 4;
        level = 2;
    }
    #endregion
    
    #region ƒÛ„ËÂ ÏÂÚÓ‰˚
    public void BtnBackMenu()
    {
        level -= 1;
        if (level == 2) Title.text = title;
    }
    public void CLickContent()
    {
        level = 3;
    }
    public void CLickVideo()
    {
        level = 4;
        MediaPlayer.SetActive(true);
        btnbck.transform.GetChild(0).gameObject.SetActive(true);
        btnbck.transform.GetChild(1).gameObject.SetActive(false);
        btnbck.transform.GetChild(2).gameObject.SetActive(true);
        btnbck.transform.GetChild(3).gameObject.SetActive(false);
        btnbck.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().color = Color.white;
        //titleT.SetActive(false);
    }
    public void CLickFacts()
    {
        this.GetComponent<Facts>().factsList = new List<string> {"“ÂÍÒÚ ÔÂ‚Ó„Ó Ù‡ÍÚ‡", "“ÂÍÒÚ ‚ÚÓÓ„Ó Ù‡ÍÚ‡", 
            "“ÂÍÒÚ ÚÂÚ¸Â„Ó Ù‡ÍÚ‡", "“ÂÍÒÚ ˜ÂÚ‚ÂÚÓ„Ó Ù‡ÍÚ‡", "“ÂÍÒÚ ÔˇÚÓ„Ó Ù‡ÍÚ‡"};
        this.GetComponent<Facts>().CreateFacts();
        level = 4;
        Facts.SetActive(true);
    }
    public void CLickPhotos()
    {
        level = 4;
        Photos.SetActive(true);
    }
    public void CLickOnePhoto()
    {
        level = 5;
        //MediaPlayer.SetActive(true);
        btnbck.transform.GetChild(0).gameObject.SetActive(true);
        btnbck.transform.GetChild(1).gameObject.SetActive(false);
        btnbck.transform.GetChild(2).gameObject.SetActive(true);
        btnbck.transform.GetChild(3).gameObject.SetActive(false);
        btnbck.transform.GetChild(4).gameObject.GetComponent<TMP_Text>().color = Color.white;
        titleT.SetActive(false);
    }
    #endregion
}
