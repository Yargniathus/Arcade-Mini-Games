using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameNyrkki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        PlayerPrefs.SetInt("NyrkkiPoints", 0);
        PlayerPrefs.SetString("PreviousModeNyrkki", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
