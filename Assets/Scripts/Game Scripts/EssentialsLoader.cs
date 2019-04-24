using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(UIScreen);
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
