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
    
    
    #region Приватные методы
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

    #region Кнопки Категорий
    public void BtnCategory1()
    {
        Title.text = title = "Музыка";
        Description.text =  "Отношение писателя к классической музыке, песенному творчеству, как к «музыкальному " +
                            "началу» придает каждому из его произведений особое звучание. Редкое произведение не " +
                            "содержит песенных цитат, а сама музыка в понимании автора раскрывается как символ " +
                            "красоты и добра. В письмах он признается в своей любви к классической музыке.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"Балет", "Спектакль", "Опера", "Романсы", 
                                                    "В творчестве В.П. Астафьева", "Аудиоспектакли и аудиокниги"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"Аудиоспектакль","0","«Сон о белых горах» по повести «Царь рыба»", 
                            "Поставлен в Московском Малом театре имени А.Н. Островского (автор инсценировки, он же " +
                            "постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Аудиоспектакль","0","«Сон о белых горах» по повести «Царь рыба»", 
            "Поставлен в Московском Малом театре имени А.Н. Островского (автор инсценировки, он же " +
            "постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Аудиоспектакль","0","«Сон о белых горах» по повести «Царь рыба»", 
            "Поставлен в Московском Малом театре имени А.Н. Островского (автор инсценировки, он же " +
            "постановщик - В. Седов.)"});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory2()
    {
        Title.text = title = "Театр";
        Description.text =  "Театр Астафьева – это театр, возвышающий повседневность до ритуала, воспроизводящий " +
                            "человека в преодолении судьбы. Только герой здесь не возвышается над родом, а " +
                            "возвращает ему общие не отменимые ценности.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"Балет", "Опера", "Аудиоспектакли и аудиокниги"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"Аудиоспектакль","1","«Сон о белых горах» по повести «Царь рыба»", 
                                                "Поставлен в Московском Малом театре имени А.Н. Островского " +
                                                "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Балет","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                            "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"Спектакль","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
                                                "Красноярском ТЮЗе, 2000 год."});
        cardContent.Add(new List<string> {"Опера","2","по роману В.П. Астафьева «Прокляты и убиты»", 
                                                "Поставлен на сцене МХАТа им. А.П. Чехова в 2010 году."});
        cardContent.Add(new List<string> {"Спектакль","1","Спектакль «Прости меня» в Вологодском ТЮЗе", 
                                                "Впервые спектакль по пьесе «Прости меня», написанной В. П. Астафьевым " +
                                                "по повести «Звездопад», был поставлен в 1979 году."});
        cardContent.Add(new List<string> {"Аудиоспектакль","1","«Сон о белых горах» по повести «Царь рыба»", 
            "Поставлен в Московском Малом театре имени А.Н. Островского " +
            "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Балет","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                                     "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"Спектакль","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
            "Красноярском ТЮЗе, 2000 год."});
        cardContent.Add(new List<string> {"Опера","2","по роману В.П. Астафьева «Прокляты и убиты»", 
            "Поставлен на сцене МХАТа им. А.П. Чехова в 2010 году."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory3()
    {
        Title.text = title = "Кино";
        Description.text =  "Глубина произведений В.П.Астафьева такова, что не всегда можно постичь ее и воплотить " +
                            "силами киноискусства. Творчество писателя актуально, но по замечаниям многих режиссёров " +
                            "– «очень трудно экранизировать, потому что трудно раскрыть душу, фактически вывернуть " +
                            "её наизнанку, как это делает автор».";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"По произведениям В.П. Астафьева", "Документальные", 
            "Фильмы, упоминаемые В.П. Аставьевым в его произведениях"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"По произведениям В.П. Астафьева","1","«Сон о белых горах» по повести «Царь рыба»", 
                                                "Поставлен в Московском Малом театре имени А.Н. Островского " +
                                                "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Документальные","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                            "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"Документальные","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
                                                "Красноярском ТЮЗе, 2000 год."});
        cardContent.Add(new List<string> {"Упоминаемые в его произведениях","2","по роману В.П. Астафьева «Прокляты и убиты»", 
                                                "Поставлен на сцене МХАТа им. А.П. Чехова в 2010 году."});
        cardContent.Add(new List<string> {"По произведениям В.П. Астафьева","1","Спектакль «Прости меня» в Вологодском ТЮЗе", 
                                                "Впервые спектакль по пьесе «Прости меня», написанной В. П. Астафьевым " +
                                                "по повести «Звездопад», был поставлен в 1979 году."});
        cardContent.Add(new List<string> {"Упоминаемые в его произведениях","1","«Сон о белых горах» по повести «Царь рыба»", 
            "Поставлен в Московском Малом театре имени А.Н. Островского " +
            "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Документальные","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                                     "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"По произведениям В.П. Астафьева","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
            "Красноярском ТЮЗе, 2000 год."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory4()
    {
        Title.text = title = "Литература";
        Description.text =  "В.П. Астафьев всегда был широко открытым миру писателем. О заграничной жизни Астафьев " +
                            "знал не понаслышке. Он много путешествовал, в составе делегаций советских писателей. " +
                            "Часть материалов, имеющих отношение к зарубежным командировкам писателя, сохранилась " +
                            "в фондах КККМ.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"Личная библиотека В.П. Астафьева", "О жизни и творчестве", 
            "Зарубежная проза", "Прокляты и убиты", "Веселый солдат"});
        cardContent.Clear();
        cardContent.Add(new List<string> {"Личная библиотека В.П. Астафьева","1","«Сон о белых горах» по повести «Царь рыба»", 
                                                "Поставлен в Московском Малом театре имени А.Н. Островского " +
                                                "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"О жизни и творчестве","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                            "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"О жизни и творчестве","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
                                                "Красноярском ТЮЗе, 2000 год."});
        cardContent.Add(new List<string> {"Личная библиотека В.П. Астафьева","2","по роману В.П. Астафьева «Прокляты и убиты»", 
                                                "Поставлен на сцене МХАТа им. А.П. Чехова в 2010 году."});
        cardContent.Add(new List<string> {"Веселый солдат","1","Спектакль «Прости меня» в Вологодском ТЮЗе", 
                                                "Впервые спектакль по пьесе «Прости меня», написанной В. П. Астафьевым " +
                                                "по повести «Звездопад», был поставлен в 1979 году."});
        cardContent.Add(new List<string> {"Прокляты и убиты","1","«Сон о белых горах» по повести «Царь рыба»", 
            "Поставлен в Московском Малом театре имени А.Н. Островского " +
            "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Веселый солдат","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                                     "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"Зарубежная проза","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
            "Красноярском ТЮЗе, 2000 год."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    public void BtnCategory5()
    {
        Title.text = title = "Путешествия";
        Description.text =  "В.П. Астафьев всегда был широко открытым миру писателем. О заграничной жизни Астафьев " +
                            "знал не понаслышке. Он много путешествовал, в составе делегаций советских писателей. " +
                            "Часть материалов, имеющих отношение к зарубежным командировкам писателя, сохранилась " +
                            "в фондах КККМ.";
        textButtons.Clear();
        textButtons.AddRange(new string[] {"Россия", "Болгария", "Польша", "Югославия", "Франция", "Бельгия", 
            "Греция", "США", "Колумбия", "Германия", "Турция", "Китай", "Япония", "Польша", "Италия", "Бельгия", 
            "Шотландия", "Венгрия", "Голландия"});
                cardContent.Clear();
        cardContent.Add(new List<string> {"Россия","0","«Сон о белых горах» по повести «Царь рыба»", 
                                                "Поставлен в Московском Малом театре имени А.Н. Островского " +
                                                "(автор инсценировки, он же постановщик - В. Седов.)"});
        cardContent.Add(new List<string> {"Болгария","0","«Царь рыба»", "Поставлен в Красноярском театре оперы и " + 
                                                            "балета (композитор Владимир Пороцкий) в 1999 году."});
        cardContent.Add(new List<string> {"Польша","0","«По повести «Звездопад»", "Был поставлен спектакль в " +
                                                "Красноярском ТЮЗе, 2000 год."});
        cardContent.Add(new List<string> {"Россия","0","по роману В.П. Астафьева «Прокляты и убиты»", 
                                                "Поставлен на сцене МХАТа им. А.П. Чехова в 2010 году."});
        cardContent.Add(new List<string> {"Бельгия","0","Спектакль «Прости меня» в Вологодском ТЮЗе", 
                                                "Впервые спектакль по пьесе «Прости меня», написанной В. П. Астафьевым " +
                                                "по повести «Звездопад», был поставлен в 1979 году."});
        CardContentObject.GetComponent<Cards>().StartCreate(cardContent);
        ScrollView.GetComponent<ScrollRect>().normalizedPosition = Vector2.one;
        btnLayout1.GetComponent<ButtonFilters>().StartCreate(textButtons);
        level = 2;
    }
    #endregion
    
    #region Другие методы
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
