using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessScriptLabyrintti : MonoBehaviour
{
    // Start is called before the first frame update 
    float opacityTimer = 0;
    float startGameTimer = 5;
    GameObject darknessLabyrintti;
    GameObject instructions;
    GameObject timeUntilDarkness;
    void Start()
    {
        this.timeUntilDarkness = GameObject.Find("Countdown");
        this.instructions = GameObject.Find("Instructions");
    
        
        
    }

    // Update is called once per frame
    void Update()
    {   
        opacityTimer += Time.deltaTime;
        startGameTimer = 5 - opacityTimer;
        if (startGameTimer > 0)
        {
            this.timeUntilDarkness.GetComponent<Text>().text = "Time until darkness: " + this.startGameTimer.ToString("0");
        } else
        {
            darknessLabyrintti = GameObject.Find("Pimennys");
            darknessLabyrintti.GetComponent<SpriteRenderer>().color = new Color(1F, 1f, 1f, (opacityTimer / 2 -3));
            this.timeUntilDarkness.GetComponent<Text>().text = "SURVIVE!";
            this.instructions.GetComponent<Text>().text = "";
        }


    }
}
