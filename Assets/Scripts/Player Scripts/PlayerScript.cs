using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

    private Rigidbody2D playerRigidbody;
    private Collider2D playerCollider;
    public float moveSpeed = 1f;
    public float maxRunSpeed = 5f;
    public bool capVelocityEnabled = true;
    public float standingContactDistance = 0.1f;
    public float jumpSpeed = 50f;
    private Animator anim;

    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        if (playerRigidbody != null)
        {
            ApplyInput();
            if (capVelocityEnabled)
            {
                CapVelocity();
            }

        }
        else
        {
            Debug.LogWarning("Rigidbody not attached to player" + gameObject.name);
        }

    }

    public void ApplyInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        bool yInput = Input.GetKeyDown(KeyCode.Space);
        //left right movement
        float xforce = xInput * moveSpeed * Time.deltaTime;
        float yForce = 0;

        if (xInput != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        //jumping
        if (yInput == true)
        {
            if (playerRigidbody.velocity.y == 0)
            {
                yForce = jumpSpeed;
            }
        }
        

        Vector2 force = new Vector2(xforce, yForce);

        playerRigidbody.AddForce(force, ForceMode2D.Impulse);
        

    }

    public void CapVelocity()
    {
        float cappedXVelocity = Mathf.Min(Mathf.Abs(playerRigidbody.velocity.x), maxRunSpeed) * Mathf.Sign(playerRigidbody.velocity.x);
        float cappedYVelocity = playerRigidbody.velocity.y;
        
        playerRigidbody.velocity = new Vector3(cappedXVelocity, cappedYVelocity);
    }

    public bool IsOnTopOfCollider()
    {
        if(playerCollider)
        {
            ContactFilter2D filter2D = new ContactFilter2D();
            filter2D.useTriggers = false;

            RaycastHit2D[] results = new RaycastHit2D[10];

            //playerCollider.OverlapCollider(filter2D, results);
            playerCollider.Cast(new Vector2(0, -1), filter2D, results, standingContactDistance);

            foreach(RaycastHit2D hit in results)
            {
                    //checks to see if player is on top of a collider
                    if(hit.collider.transform.position.z == playerCollider.transform.position.z)
                {
                    return true;
                }
            }

        }

        return false;
    }
        
}
