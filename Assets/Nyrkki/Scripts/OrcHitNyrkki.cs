using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHitNyrkki : MonoBehaviour
{
    bool GotHit = false;
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
            this.gameObject.transform.Rotate(0, 0, 180f * Time.deltaTime);
            //BUG: redo to make decreasing start faster
            this.gameObject.transform.localScale = new Vector3(OrcSize.x-=0.23f*Time.deltaTime, OrcSize.y -= 0.23f*Time.deltaTime, OrcSize.z -= 0.23f*Time.deltaTime );

           
        }
    }
}
