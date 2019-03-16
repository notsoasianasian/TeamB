using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;
    
    private bool collision;

    private Rigidbody2D myBody;
    public float speed = 1f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    
	// Update is called once per frame
	void FixedUpdate ()
    {
        Move();
        ChangeDirection();
	}

    private void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("ground"));

        if(!collision)
        {
            Vector3 temp = transform.localScale;
            if(temp.x == 1f)
            {
                temp.x = -1f;
            } else
            {
                temp.x = 1f;
            }

            transform.localScale = temp;
        }
    }

    private void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            Destroy(target.gameObject);
        }
    }
}
