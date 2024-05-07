using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;
using System.IO;

public class Cards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject controller;
    public GameObject archive;
    public GameObject content;
    public GameObject contentObject;
    public GameObject contentGallery;
    public GameObject button;

    public Sprite plug;

    public List<string> filtersList = new();
    public bool change = false;

    public void StartCreate(List<string> filters=null)
    {
        ButtonFilters.DeleteAllChildren(gameObject);
        //CreateContentCard(archive.GetComponent<Archive>().objectContent, filters);
        // level = 2
        CreateShortListCards(archive.GetComponent<Archive>().objectContent, filters);
    }
    private void Update()
    {
        if (change) { StartCreate(filtersList); change = false; }
    }
    void CreateShortListCards(Archive.RootObject root, List<string> filters = null)
    {
        if (filters is null) filters = new List<string>();
        if (root.contents is null) return;
        foreach(Archive.Content card in root.contents)
        {
            // Проверки на соответствие карточки фильтрам
            if (filters.Count != 0 && !filters.Contains(card.tag.title))
                continue;
            // Создание элементов для карточек, если все условия удовлетворены
            CreateCardElements(card);
        }
    }
    void CreateCardElements(Archive.Content card)
    {
        GameObject newCard = Instantiate(cardPrefab, gameObject.transform);
        SetupButton(newCard, card);
        newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().text = card.tag.title;
        newCard.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
            newCard.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>().GetPreferredValues().x, 35f);

        newCard.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = card.title;
        if (card.description is not null) newCard.transform.GetChild(2).GetComponentInChildren<TMP_Text>().text = Archive.ConvertHTMLToTMP(card.description);

        newCard.GetComponent<RectTransform>().sizeDelta = new Vector2(421f, 264f);
        if (card.cover is null || string.IsNullOrEmpty(card.cover.url))
        { newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(false); }
        else
        {
            newCard.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.GetComponent<Cards>().StartCoroutine(LoadPictures(newCard, card));
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.gameObject.GetComponent<RectTransform>());
        Canvas.ForceUpdateCanvases();
    }
    void SetupButton(GameObject gameObject, Archive.Content card)
    {
        ClickCard clickCard = gameObject.GetComponent<ClickCard>();
        clickCard.thisCard = card;
        clickCard.content = contentObject;
        clickCard.controller = controller;
        clickCard.archive = archive;
        clickCard.contentGallery = contentGallery;
        clickCard.mediaList = card.media;
        clickCard.plug = plug;
        clickCard.button = button;


        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(clickCard.ClickOnCard);
    }
    public IEnumerator LoadPictures(GameObject card, Archive.Content content)
    {
        // Построение пути к локальному файлу
        //string filePath = Path.Combine(Application.persistentDataPath, content.cover.id + ".png");
        string filePath = Path.Combine(archive.GetComponent<Archive>().folderResizePath, content.cover.id + ".png");

        // Проверка существования файла
        if (File.Exists(filePath))
        {
            //byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = archive.GetComponent<Archive>().LoadAndResizeTexture(filePath, 1024, 1024);
            Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            Image targetImage = card.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (targetImage)
            {
                targetImage.sprite = image;
                Debug.Log("Изображение установлено!");
            }
            else
            {
                Debug.LogError("Компонент Image не найден!");
            }
        }
        else
        {
            Debug.LogError("Файл не найден: " + filePath);
        }

        yield return null;
    }
    //public IEnumerator LoadPictures(GameObject card, Archive.Content content)
    //{
    //    //Debug.LogWarning("Запуск!");
    //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(content.cover.url);
    //    archive.GetComponent<Archive>().requestManager.AddRequest(request);
    //    yield return StartCoroutine(archive.GetComponent<Archive>().requestManager.HandleRequest(request));
    //    //Debug.LogWarning(request.result);
    //    if (request.result == UnityWebRequest.Result.Success) // Проверка успешности запроса
    //    {
    //        Texture2D texture = DownloadHandlerTexture.GetContent(request);
    //        if (texture)
    //        {
    //            Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    //            //Debug.LogWarning("texture" + texture.imageContentsHash);
    //            Image targetImage = card.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Image>(); // Путь к Image должен быть указан правильно
    //            //Debug.LogWarning("targetImage.sprite"+targetImage.sprite.texture.imageContentsHash);
    //            if (targetImage)
    //            {
    //                targetImage.sprite = image;
    //                //Debug.LogWarning("targetImage.sprite"+targetImage.sprite.texture.imageContentsHash);
    //                //Debug.LogWarning("Изображение установлено!");
    //            }
    //            else
    //            {
    //                Debug.LogError("Компонент Image не найден!");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogError("Текстура не загружена из запроса.");
    //        }
    //    }
    //}
}

