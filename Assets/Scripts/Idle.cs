using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public float idleTimeThreshold = 60f; 
    private float lastActivityTime;
    void Start()
    {
        lastActivityTime = Time.time;
    }
    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            lastActivityTime = Time.time;
        }
        if (Time.time - lastActivityTime > idleTimeThreshold)
        {
            //Debug.Log("Пользователь бездействует более " + idleTimeThreshold + " секунд.");
            this.GetComponent<MainMenu>().level = 1;
        }
    }
}
