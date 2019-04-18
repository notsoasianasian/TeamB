using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        if (Door.instance != null)
        {
            Door.instance.collectiblesCount++;
        }
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);

            if (Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }
}
