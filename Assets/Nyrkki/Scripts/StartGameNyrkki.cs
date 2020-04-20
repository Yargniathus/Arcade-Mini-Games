using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameNyrkki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("NyrkkiPoints", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
