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
        print_text += "\n������: " + input_search.text;
        print_text += "\n����: " + drop_fund.value;
        print_text += "\n������: " + drop_fund_comp.value;
        print_text += "\n���������: " + this.GetComponent<Buttons>().material;
        print_text += "\n��: " + input_year0.text + " ��: " + input_year1.text;

        text.GetComponent<Text>().text = print_text;
    }
}
