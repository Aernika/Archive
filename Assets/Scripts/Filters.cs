using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;
using TMPro;

public class Filters : MonoBehaviour
{
    public TMP_Dropdown drop_fund;
    public TMP_Dropdown drop_fund_comp;
    public TMP_InputField input_year0;
    public TMP_InputField input_year1;
    public TMP_InputField input_search;
    public GameObject text;
    string print_text;
    public void Search()
    {
        print_text = "";
        print_text += "\nЗапрос: " + input_search.text;
        print_text += "\nФонд: " + drop_fund.value;
        print_text += "\nСостав: " + drop_fund_comp.value;
        print_text += "\nМатериалы: " + this.GetComponent<Buttons>().material;
        print_text += "\nОт: " + input_year0.text + " До: " + input_year1.text;

        text.GetComponent<Text>().text = print_text;
    }
}
