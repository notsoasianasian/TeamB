using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject visibility;
    public GameObject hideplayer;

    public void Resume()
    {
        hideplayer.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        visibility.gameObject.SetActive (false);
    }
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
