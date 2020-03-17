using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    //Test commit for git purposes

    public static float Timer = 0f;
    public float TimeToGUI = 0f;
    private GameObject aikaTeksti = null;
    void Start()
    {
        this.aikaTeksti = GameObject.Find("timetext");
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimeToGUI = Timer; 
        this.aikaTeksti.GetComponent<Text>().text = "Time: " + this.TimeToGUI.ToString("0");
    }
}
