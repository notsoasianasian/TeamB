using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        
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
