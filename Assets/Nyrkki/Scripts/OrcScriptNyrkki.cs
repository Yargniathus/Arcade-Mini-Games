﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScriptNyrkki : MonoBehaviour
{
    bool reachedTop;
    bool isjumping;
    private Animator orcAnimator;
    private float jumpingDownSpeed = 6f;
    

    // Start is called before the first frame update
    void Start()
    {
        isjumping = false;
        orcAnimator = GetComponent<Animator>();
        orcAnimator.SetBool("OrcAnimatorIsClimbing", true);
        
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
        JumpDownFromLadder();
    }

    void ClimbingUp()
    {
        if (!reachedTop && !GetComponent<OrcHitNyrkki>().IsRecovering)
        {

            this.gameObject.transform.Translate(new Vector3(0, 4 * Time.deltaTime));
        }
    }

    void JumpingAtPlayer()
    {
        if (isjumping && !GetComponent<OrcHitNyrkki>().IsRecovering)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            orcAnimator.SetBool("OrcAnimatorIsAttacking", true);
            if (this.gameObject.GetComponent<Transform>().position.x <0)
            {
                this.gameObject.transform.Translate(new Vector3(7 * Time.deltaTime, 0));
            }
            if (this.gameObject.GetComponent<Transform>().position.x > 0)
            {
                this.gameObject.transform.Translate(new Vector3(-7 * Time.deltaTime, 0));
            }
            this.gameObject.transform.Translate(new Vector3(0, -20 * Time.deltaTime ));
            Vector3 OrcSize = this.gameObject.transform.localScale;
            this.gameObject.transform.localScale += new Vector3(OrcSize.x * 1.5f * Time.deltaTime * 3, OrcSize.y * 1.5f * Time.deltaTime * 3, OrcSize.z * 1.5f * Time.deltaTime * 3);
            if (OrcSize.x>7)
            {
                HitsPlayer();
                Destroy(this.gameObject);
            }

        }
    }
    IEnumerator JumpingStartCoroutine()
    {

        
        orcAnimator.SetBool("OrcAnimatorIsClimbing", false);
        orcAnimator.SetBool("OrcAnimatorIsPreparing", true);  
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 60;
        yield return new WaitForSeconds(1);
      
        var hitCheck = this.gameObject.GetComponent<OrcHitNyrkki>();
        if (!hitCheck.isDying)
        {
            isjumping = true;
        }
        
    }
    void HitsPlayer()
    {
        //remove life
        var codeStorage = GameObject.Find("MainCamera");
        codeStorage.GetComponent<LifeTrackerNyrkki>().lifeTracker -= 1;
        int lifeTracker = codeStorage.GetComponent<LifeTrackerNyrkki>().lifeTracker;
        codeStorage.GetComponent<BloodInstantiateNyrkki>().OrcHitsPlayer();
        Destroy(GameObject.Find("Heart" + lifeTracker.ToString()));
        Debug.Log(lifeTracker);
    }
    void JumpDownFromLadder()
    {
        if (!reachedTop)
        {
            return;
        }
        else
        {
            

            if (gameObject.GetComponent<Transform>().position.y > 0)
            {
                    gameObject.transform.Translate(new Vector3(0, -jumpingDownSpeed * Time.deltaTime));          
            }
            

        }
    }

}
