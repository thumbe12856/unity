using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimerManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public static float timer;
    public GameObject arrow;
    Text text;
    bool isActice;

    void Awake()
    {
        text = GetComponent<Text>();
        timer = 30.0f;
        isActice = false;
    }


    void Update()
    {
        if ((timer - Time.deltaTime > 0) && playerHealth.currentHealth > 0)
        {
            timer -= Time.deltaTime;
            text.text = "" + Math.Round(timer, 2);            
        }
        else if(timer - Time.deltaTime < 0 && !isActice)
        {
            isActice = true;
            timer = -1;
            arrow.SetActive(true);
            text.text = "";
        }
        else if(playerHealth.currentHealth <= 0)
        {
            text.text = "";
        }
    }
}
