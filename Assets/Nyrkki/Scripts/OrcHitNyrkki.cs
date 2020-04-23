using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcHitNyrkki : MonoBehaviour
{
    public bool GotHit = false;
    public GameObject flash;
    private float timeBetweenHitAndDeath = 3f;
    private int points;
    private Animator orcAnimator;
    private int orcHP;
    Color orcColor;
    // Start is called before the first frame update
    void Start()
    {
        orcHP = Random.Range(1, 600);
       if(orcHP<400)
        {
            orcColor = new Color(0.6155064f, 1, 0.5613208f);
        }else
        {
            if (orcHP>549)
            {
                orcColor = new Color(1f, 0.645642f, 0.5607843f);
            }
            else
            {
                orcColor = new Color(1, 0.940287f, 0.511f);
            }
        }
        GetComponent<SpriteRenderer>().color = orcColor;
        orcAnimator = GetComponent<Animator>();
        orcAnimator.SetBool("OrcAnimatorIsDead", false);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            //prevent multiple collisions
            if (GotHit)
            { return; }            
            //make orc fly off
            GotHit = true;
            StartCoroutine(OrcDestructionCoroutine());
            
            //Destroy orc object
            Destroy(this.gameObject, timeBetweenHitAndDeath);
            
        }

    }
    void Update()
    {
       

        if (GotHit)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            orcAnimator.SetBool("OrcAnimatorIsDead", true);
            Vector3 OrcSize = this.gameObject.transform.localScale;
            this.gameObject.transform.Translate(0, 1f * Time.deltaTime, 0, Space.World);
            this.gameObject.transform.Translate(0, 0.5f * Time.deltaTime, 0);
            this.gameObject.transform.Rotate(0, 0, 360f * Time.deltaTime);            
            this.gameObject.transform.localScale -= new Vector3(OrcSize.x*0.9999f*Time.deltaTime*3, OrcSize.y * 0.9999f * Time.deltaTime*3, OrcSize.z * 0.9999f * Time.deltaTime*3 );

           
        }
    }
    IEnumerator OrcDestructionCoroutine()
    {
       
        yield return new WaitForSeconds(timeBetweenHitAndDeath-0.5f);
        //Add score
        points = PlayerPrefs.GetInt("NyrkkiPoints") + 1;
        PlayerPrefs.SetInt("NyrkkiPoints", points);
        Debug.Log(PlayerPrefs.GetInt("NyrkkiPoints"));
        //make bling in the sky
        Instantiate(flash, new Vector3(this.gameObject.GetComponent<Transform>().position.x, this.gameObject.GetComponent<Transform>().position.y), Quaternion.identity);
        

    }
}
