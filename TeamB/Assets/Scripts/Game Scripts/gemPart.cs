using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemPart : MonoBehaviour
{
    public GameObject dustCloud;
   // public AudioSource audio;

    void Start()
    {
       // audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
           // audio.Play();
            Instantiate(dustCloud, transform.position, dustCloud.transform.rotation);

        }

    }
}
