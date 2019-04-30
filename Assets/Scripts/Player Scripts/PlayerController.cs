using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Collider2D playerCollider;

    public float moveForce, jumpForce, maxVelocity;
    private bool grounded;
    private Animator anim;
    public static PlayerController instance;
    public string areaTransitionName;

    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void FixedUpdate()
    {
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(playerRigidbody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = moveForce;
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -moveForce;
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }

        playerRigidbody.AddForce(new Vector2(forceX, forceY));
    }

}
