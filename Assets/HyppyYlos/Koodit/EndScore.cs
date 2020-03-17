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
        this.GetComponent<Text>().text = "Score: " + endScore.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
