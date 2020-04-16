using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScriptNyrkki : MonoBehaviour
{
    bool reachedTop;
    bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        isjumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Transform>().position.y >= 2)
        {
            reachedTop = true;
            StartCoroutine(JumpingStartCoroutine());
        }

        if (this.gameObject.GetComponent<Transform>().position.y >=0 && !isjumping)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        ClimbingUp();
        JumpingAtPlayer();
    }

    void ClimbingUp()
    {
        if (!reachedTop)
        {

            this.gameObject.transform.Translate(new Vector3(0, 2 * Time.deltaTime));
        }
    }

    void JumpingAtPlayer()
    {
        if (isjumping)
        {
            if (this.gameObject.GetComponent<Transform>().position.x <0)
            {
                this.gameObject.transform.Translate(new Vector3(7 * Time.deltaTime, 0));
            }
            if (this.gameObject.GetComponent<Transform>().position.x > 0)
            {
                this.gameObject.transform.Translate(new Vector3(-7 * Time.deltaTime, 0));
            }
            Vector3 OrcSize = this.gameObject.transform.localScale;
            this.gameObject.transform.localScale += new Vector3(OrcSize.x * 1.5f * Time.deltaTime * 3, OrcSize.y * 1.5f * Time.deltaTime * 3, OrcSize.z * 1.5f * Time.deltaTime * 3);
            if (OrcSize.x>7)
            {
                Destroy(this.gameObject);
            }

        }
    }
    IEnumerator JumpingStartCoroutine()
    {

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 60;
        var hitCheck = this.gameObject.GetComponent<OrcHitNyrkki>();
        if (!hitCheck.GotHit)
        {
            isjumping = true;
        }
        
    }
}
