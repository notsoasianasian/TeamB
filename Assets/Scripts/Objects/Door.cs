using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;
    private BoxCollider2D box;
    private Animator anim;
    [HideInInspector]
    public int collectiblesCount;

	// Use this for initialization
	void Awake ()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
	}

    private void MakeInstance ()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectables ()
    {
        collectiblesCount--;

        if(collectiblesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }
	
    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Debug.Log("game finished");
        }
    }
}
