using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcInstantiateNyrkki : MonoBehaviour
{
    private float time;
    private float spawnInterval;
    public GameObject Orc;
    void Start()
    {
        spawnInterval = 1.5f;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time>=spawnInterval)
        {
            int rnd = Random.Range(1, 4);
            time = time - spawnInterval;
            switch(rnd)
            {
                case 1:
                    {
                        Instantiate(Orc, new Vector3(-5, -4), Quaternion.identity);
                        break;
                    }

                case 2:
                    {
                        Instantiate(Orc, new Vector3(0, -4), Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        Instantiate(Orc, new Vector3(5, -4), Quaternion.identity);
                        break;
                    }
            }

            
        }
        
    }
}
