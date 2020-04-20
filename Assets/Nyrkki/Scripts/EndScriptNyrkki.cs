using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScriptNyrkki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float endScoreNyrkki = PlayerPrefs.GetFloat("NyrkkiPoints");
        this.GetComponent<Text>().text = "SCORE: " + endScoreNyrkki.ToString();
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
            SceneManager.LoadScene("NyrkkiMain");
        }
    }
}
