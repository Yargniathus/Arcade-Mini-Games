using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNyrkki : MonoBehaviour
{
    private float time;
    private float spawnInterval;
    public GameObject Orc;
    public GameObject Seal;
    void Start()
    {
        spawnInterval = 3.5f;
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time>=spawnInterval)
        {
            int rnd = Random.Range(1, 5);
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
                case 4:
                    {
                        SealSpawn();
                        break;
                    }
            }

            
        }
        
    }

    void SealSpawn()
    {
        int rnd = Random.Range(1, 4);
        switch (rnd)
        {
            case 1:
                {
                    Instantiate(Seal, new Vector3(-5, -5.71f), Quaternion.identity);
                    break;
                }

            case 2:
                {
                    Instantiate(Seal, new Vector3(0, -5.71f), Quaternion.identity);
                    break;
                }
            case 3:
                {
                    Instantiate(Seal, new Vector3(5, -5.71f), Quaternion.identity);
                    break;
                }
        }
    }
}
