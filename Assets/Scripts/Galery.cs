using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Video;

public class Galery : MonoBehaviour
{
    //public ArсhiveContent.Card thisCard;
    public GameObject controller;
    public GameObject archive;
    public GameObject galeryPrefab;
    public List<int> indexContent;
    //public RenderTexture videoTexture;

    public void ClickGalery(List<int> photos, List<int> videos)
    {
        ButtonFilters.DeleteAllChildren(gameObject);
        if (photos is not null)
        {
            foreach (int idPhoto in photos)
            {
                GameObject newImg = Instantiate(galeryPrefab, gameObject.transform);
                Button btnImg = newImg.GetComponent<Button>();
                btnImg.onClick.AddListener(gameObject.GetComponent<Galery>().ClickPhoto);
                newImg.GetComponent<Image>().sprite = archive.GetComponent<ArсhiveContent>().GetImage(idPhoto);
                indexContent.Add(idPhoto);
            }
        }
        if (videos is not null)
        {
            foreach (int idVideo in videos)
            {
                GameObject newVideo = Instantiate(galeryPrefab, gameObject.transform);
                Button btnVideo = newVideo.GetComponent<Button>();
                btnVideo.onClick.AddListener(gameObject.GetComponent<Galery>().ClickVideo);
                
                GetComponent<VideoPlayer>().clip = archive.GetComponent<ArсhiveContent>().GetVideo(idVideo);
                /*
                RenderTexture renderTexture;
                renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
                // Инициализация RenderTexture
                renderTexture.Create();
                GetComponent<VideoPlayer>().targetTexture = videoTexture;

                GetComponent<VideoPlayer>().Play();
                GetComponent<VideoPlayer>().time = 10f;
                //GetComponent<VideoPlayer>().Stop();
                RenderTexture.active = renderTexture;
                renderTexture = videoTexture;
                Texture2D frameTexture = new Texture2D(renderTexture.width, renderTexture.height);
                frameTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                frameTexture.Apply();
                Sprite sprite = Sprite.Create(frameTexture, new Rect(0, 0, frameTexture.width, frameTexture.height), new Vector2(0.5f, 0.5f));
                */
                newVideo.GetComponent<Image>().sprite = archive.GetComponent<ArсhiveContent>().GetImage(0);
                newVideo.GetComponent<Image>().preserveAspect = true;
                newVideo.GetComponent<Image>().fillMethod = Image.FillMethod.Vertical;
                //newVideo.GetComponent<Image>().fillOrigin = (int)Image.OriginVertical.Top;
                //newVideo.GetComponent<Image>().fillOrigin += (int)Image.OriginHorizontal.Left;
                indexContent.Add(idVideo); 
                
            }
        }
    }

    public void ClickPhoto()
    {
        
    }
    
    public void ClickVideo()
    {
        
    }
}
