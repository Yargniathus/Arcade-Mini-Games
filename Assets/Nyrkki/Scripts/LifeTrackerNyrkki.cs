using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeTrackerNyrkki : MonoBehaviour
{
    public int lifeTracker;
    // Start is called before the first frame update
    void Start()
    {
        lifeTracker = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTracker<2)
        {
            SceneManager.LoadScene("NyrkkiDeath");
        }
    }
    
}
