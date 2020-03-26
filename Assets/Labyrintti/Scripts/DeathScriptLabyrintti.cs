using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScriptLabyrintti : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            Debug.Log("Collsiion");
            SceneManager.LoadScene("LabyrinttiGameOver");
        }
    }
}
