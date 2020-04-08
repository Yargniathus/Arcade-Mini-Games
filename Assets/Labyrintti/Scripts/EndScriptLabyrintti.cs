using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScriptLabyrintti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("LabyrinttiRandomLevel");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerPrefs.SetInt("LabyrinttiLevel", 1);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
