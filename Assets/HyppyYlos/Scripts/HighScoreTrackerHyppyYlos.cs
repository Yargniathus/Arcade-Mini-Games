using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTrackerHyppyYlos : MonoBehaviour
{
    public static bool IsHighScore;
      //testing purposes  
    public float currentHighScore;



    // Start is called before the first frame update
    void Start()
    {
        IsHighScore = false;
        currentHighScore = PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCounter.Timer > currentHighScore)
        {
            IsHighScore = true;
        }
    }
}
