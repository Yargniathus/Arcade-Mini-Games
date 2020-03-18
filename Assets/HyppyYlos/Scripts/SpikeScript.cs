using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            PlayerPrefs.SetFloat("points", TimeCounter.Timer);
            PlayerPrefs.SetString("reasonOfDeath", "You've been brutally impaled by a stalagmite.");

            SceneManager.LoadScene("HyppyYlosEnd");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
