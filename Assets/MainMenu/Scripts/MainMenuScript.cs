using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int chosenMenuOption;
    private int maxMenuOption;
    Outline game1;
    Outline game2;
    Outline credits;
    
    
    void Start()
    {
        chosenMenuOption = 0;
        maxMenuOption = 2;
        game1 = GameObject.Find("Game1").GetComponent<Outline>();
        game2 = GameObject.Find("Game2").GetComponent<Outline>();
        credits = GameObject.Find("Credits").GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (chosenMenuOption < maxMenuOption)
            {
                chosenMenuOption++;
            }
            else
            {
                chosenMenuOption = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (chosenMenuOption > 0)
            {
                chosenMenuOption--;
            }
            else
            {
                chosenMenuOption = maxMenuOption;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (game1.enabled == true)
            {
                SceneManager.LoadScene("HyppyYlosMain");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (game2.enabled == true)
            {
                SceneManager.LoadScene("LabyrinttiLevel1");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (credits.enabled == true)
            {
                //Not implemented yet
                //SceneManager.LoadScene("Credits");
               
            }
        }

        switch (chosenMenuOption)
        {
            case 0:
                game1.enabled = true;
                game2.enabled = false;
                credits.enabled = false;
                break;
            case 1:
                game1.enabled = false;
                game2.enabled = true;
                credits.enabled = false;
                break;
            case 2:
                game1.enabled = false;
                game2.enabled = false;
                credits.enabled = true;
                break;
        }
    }
}
