using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float endScore = PlayerPrefs.GetFloat("points");
        string endReasonOfDeath = PlayerPrefs.GetString("reasonOfDeath");

        GameObject.Find("deathreason").GetComponent<Text>().text = endReasonOfDeath;
        this.GetComponent<Text>().text = "Score: " + endScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
