using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MainContent;
    public GameObject PanelTop;
    public GameObject ScrollView;
    public GameObject Object;
    public int level;
    public string title;
    public TMP_Text Title;

    void Start()
    {
        level = 1;
        ChangeCategory(level);
    }
    void ChangeCategory(int lv)
    {
        if(lv == 1)
        {
            MainContent.SetActive(true);
            PanelTop.SetActive(false);
            ScrollView.SetActive(false);
            Object.SetActive(false);
        }
        else if (lv == 2)
        {
            MainContent.SetActive(false);
            PanelTop.SetActive(true);
            ScrollView.SetActive(true);
            Object.SetActive(false);
        }
        else if (lv == 3)
        {
            PanelTop.SetActive(true);
            ScrollView.SetActive(false);
            Object.SetActive(true);
        }
    }
    public void BtnCategory1()
    {
        Title.text = title = "Музыка";
        level = 2;
        ChangeCategory(level);
        
    }
    public void BtnCategory2()
    {
        Title.text = title = "Театр";
        level = 2;
        ChangeCategory(level);
    }
    public void BtnCategory3()
    {
        Title.text = title = "Кино";
        level = 2;
        ChangeCategory(level);
    }
    public void BtnCategory4()
    {
        Title.text = title = "Литература";
        level = 2;
        ChangeCategory(level);
    }
    public void BtnCategory5()
    {
        Title.text = title = "Путешествия";
        level = 2;
        ChangeCategory(level);
    }
    public void BtnBackMenu()
    {
        level -= 1;
        if (level == 2) Title.text = title;
        ChangeCategory(level);
    }
    public void CLickContent()
    {
        Title.text = "Царь рыба";
        level = 3;
        ChangeCategory(level);
    }
}
