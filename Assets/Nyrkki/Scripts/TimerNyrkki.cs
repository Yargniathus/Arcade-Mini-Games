using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerNyrkki : MonoBehaviour
{  

    public float Timer = 0f;
    public float TimeToGUI = 0f;
    private GameObject timeText = null;

    void Start()
    {
        Timer = 0f;
        this.timeText = GameObject.Find("Timer");
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimeToGUI = 40-Timer;
        this.timeText.GetComponent<Text>().text = "Time: " + this.TimeToGUI.ToString("0");
        if (TimeToGUI<=0)
        {
            SceneManager.LoadScene("NyrkkiVictory");
        }
        
    }
}
