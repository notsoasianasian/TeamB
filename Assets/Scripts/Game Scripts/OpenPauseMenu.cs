using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject visibility;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0.1f;
            Cursor.visible = true;
            visibility.gameObject.SetActive(true);
        }
    }
}
