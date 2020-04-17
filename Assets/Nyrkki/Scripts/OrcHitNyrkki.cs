﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHitNyrkki : MonoBehaviour
{
    public bool GotHit = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            GotHit = true;
            Destroy(this.gameObject, 3f);

        }

    }
    void Update()
    {
        if (GotHit)
        {
            Vector3 OrcSize = this.gameObject.transform.localScale;
            this.gameObject.transform.Translate(0, 1f * Time.deltaTime, 0, Space.World);
            this.gameObject.transform.Translate(0, 0.5f * Time.deltaTime, 0);
            this.gameObject.transform.Rotate(0, 0, 360f * Time.deltaTime);
            //BUG: redo to make decreasing start faste
            this.gameObject.transform.localScale -= new Vector3(OrcSize.x*0.9999f*Time.deltaTime*3, OrcSize.y * 0.9999f * Time.deltaTime*3, OrcSize.z * 0.9999f * Time.deltaTime*3 );

           
        }
    }
}