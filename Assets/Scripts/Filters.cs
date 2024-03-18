using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Image = UnityEngine.UI.Image;

public class Filters : MonoBehaviour
{
    public Sprite blackBtn;
    public Sprite blueBtn;
    public bool status; //false = black, true = blue

    void Start()
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
        }
        else
        {
            this.GetComponent<Image>().sprite = blackBtn;
            this.GetComponent<Image>().pixelsPerUnitMultiplier = 4.09f;
            this.GetComponentInChildren<TMP_Text>().color = Color.black;
        }
    }
}
