using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    public float forceY = 300f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));

        forceY = Random.Range(250, 550);

        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(.7f);
        StartCoroutine(Attack());
   
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "ground")
        {
            anim.SetBool("Attack", false);
        }

        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }

}
