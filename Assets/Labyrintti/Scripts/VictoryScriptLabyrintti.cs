using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScriptLabyrintti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            SceneManager.LoadScene("LabyrinttiVictory");
        }
    }
}
