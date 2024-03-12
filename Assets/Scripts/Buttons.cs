using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private bool bobtn_1;
    private bool bobtn_2;
    private bool bobtn_3;
    public string material;
    void Start()
    {
        bobtn_1 = false;
        bobtn_2 = false;
        bobtn_3 = false;
        material = "";
    }
    void Update()
    {
        material = "";
        if (bobtn_1) material += "Аудио/видео";
        if (bobtn_2) material += " Фото";
        if (bobtn_3) material += " Статьи";
    }

    public void Btn_1()
    {
        if (bobtn_1) bobtn_1 = false;
        else bobtn_1 = true;
    }
    public void Btn_2()
    {
        if (bobtn_2) bobtn_2 = false;
        else bobtn_2 = true;
    }
    public void Btn_3()
    {
        if (bobtn_3) bobtn_3 = false;
        else bobtn_3 = true;
    }
}
