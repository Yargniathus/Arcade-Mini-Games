using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInstantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Platform;
    float juuriSpawnattuLaskuri = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        juuriSpawnattuLaskuri += Time.deltaTime;
        if ((transform.position.y > -0.05 && transform.position.y < 0.05) && juuriSpawnattuLaskuri > 0.3)
        {
            
            //


            if (PlatformBoolValue.LastChosenLeftPlatform == true)
            {
                PlatformBoolValue.LastChosenLeftPlatform = false;
                Instantiate(Platform, new Vector3(3.07f, -4.0f, 0), Quaternion.identity);


            }
             else
            {
                PlatformBoolValue.LastChosenLeftPlatform = true;
                Instantiate(Platform, new Vector3(-3.92f, -4.0f, 0), Quaternion.identity);
                
            }

            juuriSpawnattuLaskuri = 0;

        }
    }
}
