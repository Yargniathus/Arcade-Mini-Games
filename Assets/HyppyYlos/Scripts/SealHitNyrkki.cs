using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealHitNyrkki : MonoBehaviour
{
    
    public bool GotHit = false;
    public GameObject flash;
    private float timeBetweenHitAndDeath = 3f;
    public bool isDying;
    private int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            //prevent multiple collisions
            if (GotHit)
            { return; }
            GotHit = true;
            isDying = true;
            points = PlayerPrefs.GetInt("NyrkkiPoints") - 200;
            PlayerPrefs.SetInt("NyrkkiPoints", points);
            Debug.Log(PlayerPrefs.GetInt("NyrkkiPoints"));
            //Destroy seal object
            Destroy(this.gameObject, timeBetweenHitAndDeath);
        }

    }
    void Update()
    {

        if (GotHit && isDying)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            Vector3 sealSize = this.gameObject.transform.localScale;
            this.gameObject.transform.Translate(0, -3.5f * Time.deltaTime, 0, Space.World);
            this.gameObject.transform.Rotate(0, 0, 90f * Time.deltaTime);
        }
    }
}

