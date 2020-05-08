using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealMovementNyrkki : MonoBehaviour
{
    public bool SealReachedTop;
    public bool SealIsGoingDown;
    // Start is called before the first frame update
    void Start()
    {
        SealReachedTop = false;
        SealIsGoingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SealReachedTop)
        {
            this.gameObject.transform.Translate(new Vector3(0, 5 * Time.deltaTime));
        }

        if (this.gameObject.GetComponent<Transform>().position.y > -2.9)
        {
            SealReachedTop = true;
            StartCoroutine(ReachingTopCoroutine());
        }
        if (SealIsGoingDown)
        {
            this.gameObject.transform.Translate(new Vector3(0, -5 * Time.deltaTime));
        }
        if (this.gameObject.GetComponent<Transform>().position.y <-5.46)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator ReachingTopCoroutine()
    {
        yield return new WaitForSeconds(1);

        SealIsGoingDown = true;
    }
}
