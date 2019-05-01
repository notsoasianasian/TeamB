using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Collider2D playerCollider;
    public string levelToLoad;

    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;
    private bool grounded = true;
    private Animator anim;
    public static PlayerController instance;
    public string areaTransitionName;

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //playerCollider = GetComponent<Collider2D>();
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

        
    }

    public void FixedUpdate()
    {
        PlayerWalkKeyboard();
    }

    void PlayerWalkKeyboard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.velocity.x);

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

            anim.SetBool("Jump", false);
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

            anim.SetBool("Jump", false);
            anim.SetBool("Walk", true);
        }
        else if (h == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Walk", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
           
                forceY = jumpForce;

                anim.SetBool("Walk", false);
                anim.SetBool("Jump", true);
           
        }

        myBody.AddForce(new Vector2(forceX, forceY));
    }

   
    public void OnDestroy()
    {
        SceneManager.LoadScene("game over");
    }
}
