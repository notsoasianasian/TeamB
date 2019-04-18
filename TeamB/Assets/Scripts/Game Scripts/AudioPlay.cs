using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour

{ //public AudioClip sound;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();

  
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "gem")
        {

            audio.Play();
        }
    }
}
