using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float endScore = PlayerPrefs.GetFloat("points");
        string endReasonOfDeath = PlayerPrefs.GetString("reasonOfDeath");
        float highScore = PlayerPrefs.GetFloat("highscore");

        GameObject.Find("deathreason").GetComponent<Text>().text = endReasonOfDeath;
        this.GetComponent<Text>().text = "Score: " + endScore.ToString("0");
        GameObject.Find("highscore").GetComponent<Text>().text = "High Score: " + highScore.ToString("0");
        if (endScore == highScore)
        {
            GameObject.Find("reachedhighscore").GetComponent<Text>().text = "NEW HIGH SCORE!";
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("HyppyYlosMain");
        }
    }
}
