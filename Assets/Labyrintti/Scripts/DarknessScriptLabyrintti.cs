using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessScriptLabyrintti : MonoBehaviour
{
    // Start is called before the first frame update 
    float opacityTimer = 0;
    public float startGameTimer = 10;
    GameObject darknessLabyrintti;
    GameObject timeUntilDarkness;
    bool lightIncreasing = true;
    void Start()
    {
        this.timeUntilDarkness = GameObject.Find("Countdown");
        darknessLabyrintti = GameObject.Find("Pimennys");

    }

    void Update()
    {
        if (GameStartLabyrintti.LabyrinttiGameStarted != false)
        {
            opacityTimer += Time.deltaTime;
            startGameTimer = 10 - opacityTimer;
            if (startGameTimer < 2)
            {
                darknessLabyrintti.GetComponent<SpriteRenderer>().color = new Color(1F, 1f, 1f, (opacityTimer / 2 - 4));
            }
            if (startGameTimer > 0)
            {
                this.timeUntilDarkness.GetComponent<Text>().text = "Time until darkness: " + this.startGameTimer.ToString("0");
            }
            else
            {
             
                this.timeUntilDarkness.GetComponent<Text>().text = "SURVIVE!";
                
                if (lightIncreasing == true)
                {
                    Vector3 previousCircleOfLight = darknessLabyrintti.transform.localScale;
                    darknessLabyrintti.transform.localScale = new Vector3(previousCircleOfLight.x += 0.3f, previousCircleOfLight.y += 0.3f, previousCircleOfLight.z += 0.3f);
                    if (darknessLabyrintti.transform.localScale.x > 120)
                    { lightIncreasing = false; }
                }
                if (lightIncreasing == false)
                {
                    Vector3 previousCircleOfLight = darknessLabyrintti.transform.localScale;
                    darknessLabyrintti.transform.localScale = new Vector3(previousCircleOfLight.x -= 0.3f, previousCircleOfLight.y -= 0.3f, previousCircleOfLight.z -= 0.3f);
                    if (darknessLabyrintti.transform.localScale.x < 110)
                    { lightIncreasing = true; }
                }
            }
        }


    }
}
