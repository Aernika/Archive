using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public GameObject MainContent;
    public GameObject PanelTop;
    public GameObject ScrollView;
    public GameObject Object;
    public GameObject btnLayout1;
    public GameObject btnLayout2;
    public GameObject CardContentObject;

    public int level;
    private int levelOld;
    public string title;
    public TMP_Text Title;
    public TMP_Text Description;
    public List<String> textButtons;
    private List<List<String>> cardContent;
    
    
    #region ��������� ������
    void Start()
    {
        level = levelOld = 1;
        ChangeCategory(level);
        cardContent = new List<List<String>>();
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
            levelOld = 3;
        }
    }
    #endregion

    #region ������ ���������
    public void BtnCategory1()
    {
        Title.text = title = "������";
        Description.text =  "��������� �������� � ������������ ������, ��������� ����������, ��� � ������������� " +
                            "������ ������� ������� �� ��� ������������ ������ ��������. ������ ������������ �� " +
                            "�������� �������� �����, � ���� ������ � ��������� ������ ������������ ��� ������ " +
                            "������� � �����. � ������� �� ���������� � ����� ����� � ������������ ������.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"�����", "���������", "�����", "�������", 
                                                    "� ���������� �.�. ���������", "�������������� � ����������"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"��������������","0","���� � ����� ������ �� ������� ����� ����", 
                            "��������� � ���������� ����� ������ ����� �.�. ����������� (����� ������������, �� �� " +
                            "����������� - �. �����.)"});
        cardContent.Add(new List<string> {"��������������","0","���� � ����� ������ �� ������� ����� ����", 
            "��������� � ���������� ����� ������ ����� �.�. ����������� (����� ������������, �� �� " +
            "����������� - �. �����.)"});
        cardContent.Add(new List<string> {"��������������","0","���� � ����� ������ �� ������� ����� ����", 
            "��������� � ���������� ����� ������ ����� �.�. ����������� (����� ������������, �� �� " +
            "����������� - �. �����.)"});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory2()
    {
        Title.text = title = "�����";
        Description.text =  "����� ��������� � ��� �����, ����������� �������������� �� �������, ��������������� " +
                            "�������� � ����������� ������. ������ ����� ����� �� ����������� ��� �����, � " +
                            "���������� ��� ����� �� ��������� ��������.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"�����", "�����", "�������������� � ����������"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"��������������","1","���� � ����� ������ �� ������� ����� ����", 
                                                "��������� � ���������� ����� ������ ����� �.�. ����������� " +
                                                "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"�����","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                            "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"���������","0","��� ������� ����������", "��� ��������� ��������� � " +
                                                "������������ ����, 2000 ���."});
        cardContent.Add(new List<string> {"�����","2","�� ������ �.�. ��������� ��������� � ������", 
                                                "��������� �� ����� ����� ��. �.�. ������ � 2010 ����."});
        cardContent.Add(new List<string> {"���������","1","��������� ������� ����� � ����������� ����", 
                                                "������� ��������� �� ����� ������� �����, ���������� �. �. ���������� " +
                                                "�� ������� ����������, ��� ��������� � 1979 ����."});
        cardContent.Add(new List<string> {"��������������","1","���� � ����� ������ �� ������� ����� ����", 
            "��������� � ���������� ����� ������ ����� �.�. ����������� " +
            "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"�����","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                                     "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"���������","0","��� ������� ����������", "��� ��������� ��������� � " +
            "������������ ����, 2000 ���."});
        cardContent.Add(new List<string> {"�����","2","�� ������ �.�. ��������� ��������� � ������", 
            "��������� �� ����� ����� ��. �.�. ������ � 2010 ����."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory3()
    {
        Title.text = title = "����";
        Description.text =  "������� ������������ �.�.��������� ������, ��� �� ������ ����� ������� �� � ��������� " +
                            "������ �������������. ���������� �������� ���������, �� �� ���������� ������ ��������� " +
                            "� ������ ������ ��������������, ������ ��� ������ �������� ����, ���������� ��������� " +
                            "� ���������, ��� ��� ������ �����.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"�� ������������� �.�. ���������", "��������������", 
            "������, ����������� �.�. ���������� � ��� �������������"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"�� ������������� �.�. ���������","1","���� � ����� ������ �� ������� ����� ����", 
                                                "��������� � ���������� ����� ������ ����� �.�. ����������� " +
                                                "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"��������������","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                            "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"��������������","0","��� ������� ����������", "��� ��������� ��������� � " +
                                                "������������ ����, 2000 ���."});
        cardContent.Add(new List<string> {"����������� � ��� �������������","2","�� ������ �.�. ��������� ��������� � ������", 
                                                "��������� �� ����� ����� ��. �.�. ������ � 2010 ����."});
        cardContent.Add(new List<string> {"�� ������������� �.�. ���������","1","��������� ������� ����� � ����������� ����", 
                                                "������� ��������� �� ����� ������� �����, ���������� �. �. ���������� " +
                                                "�� ������� ����������, ��� ��������� � 1979 ����."});
        cardContent.Add(new List<string> {"����������� � ��� �������������","1","���� � ����� ������ �� ������� ����� ����", 
            "��������� � ���������� ����� ������ ����� �.�. ����������� " +
            "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"��������������","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                                     "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"�� ������������� �.�. ���������","0","��� ������� ����������", "��� ��������� ��������� � " +
            "������������ ����, 2000 ���."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory4()
    {
        Title.text = title = "����������";
        Description.text =  "�.�. �������� ������ ��� ������ �������� ���� ���������. � ����������� ����� �������� " +
                            "���� �� ����������. �� ����� �������������, � ������� ��������� ��������� ���������. " +
                            "����� ����������, ������� ��������� � ���������� ������������� ��������, ����������� " +
                            "� ������ ����.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"������ ���������� �.�. ���������", "� ����� � ����������", 
            "���������� �����", "�������� � �����", "������� ������"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"������ ���������� �.�. ���������","1","���� � ����� ������ �� ������� ����� ����", 
                                                "��������� � ���������� ����� ������ ����� �.�. ����������� " +
                                                "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"� ����� � ����������","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                            "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"� ����� � ����������","0","��� ������� ����������", "��� ��������� ��������� � " +
                                                "������������ ����, 2000 ���."});
        cardContent.Add(new List<string> {"������ ���������� �.�. ���������","2","�� ������ �.�. ��������� ��������� � ������", 
                                                "��������� �� ����� ����� ��. �.�. ������ � 2010 ����."});
        cardContent.Add(new List<string> {"������� ������","1","��������� ������� ����� � ����������� ����", 
                                                "������� ��������� �� ����� ������� �����, ���������� �. �. ���������� " +
                                                "�� ������� ����������, ��� ��������� � 1979 ����."});
        cardContent.Add(new List<string> {"�������� � �����","1","���� � ����� ������ �� ������� ����� ����", 
            "��������� � ���������� ����� ������ ����� �.�. ����������� " +
            "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"������� ������","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                                     "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"���������� �����","0","��� ������� ����������", "��� ��������� ��������� � " +
            "������������ ����, 2000 ���."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory5()
    {
        Title.text = title = "�����������";
        Description.text =  "�.�. �������� ������ ��� ������ �������� ���� ���������. � ����������� ����� �������� " +
                            "���� �� ����������. �� ����� �������������, � ������� ��������� ��������� ���������. " +
                            "����� ����������, ������� ��������� � ���������� ������������� ��������, ����������� " +
                            "� ������ ����.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"������", "��������", "������", "���������", "�������", "�������", 
            "������", "���", "��������", "��������", "������", "�����", "������", "������", "������", "�������", 
            "���������", "�������", "���������"});
                cardContent.Clear();
        cardContent.Add(new List<string> {"������","0","���� � ����� ������ �� ������� ����� ����", 
                                                "��������� � ���������� ����� ������ ����� �.�. ����������� " +
                                                "(����� ������������, �� �� ����������� - �. �����.)"});
        cardContent.Add(new List<string> {"��������","0","����� ����", "��������� � ������������ ������ ����� � " + 
                                                            "������ (���������� �������� ��������) � 1999 ����."});
        cardContent.Add(new List<string> {"������","0","��� ������� ����������", "��� ��������� ��������� � " +
                                                "������������ ����, 2000 ���."});
        cardContent.Add(new List<string> {"������","0","�� ������ �.�. ��������� ��������� � ������", 
                                                "��������� �� ����� ����� ��. �.�. ������ � 2010 ����."});
        cardContent.Add(new List<string> {"�������","0","��������� ������� ����� � ����������� ����", 
                                                "������� ��������� �� ����� ������� �����, ���������� �. �. ���������� " +
                                                "�� ������� ����������, ��� ��������� � 1979 ����."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    #endregion
    
    #region ������ ������
    public void BtnBackMenu()
    {
        level -= 1;
        if (level == 2) Title.text = title;
    }
    public void CLickContent()
    {
        level = 3;
    }
    #endregion
}
