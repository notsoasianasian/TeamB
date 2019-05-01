using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject switchMainMenu;
    public GameObject switchControlMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void OpenControls()
    {
        switchMainMenu.gameObject.SetActive(false);
        switchControlMenu.gameObject.SetActive(true);
    }
    public void CloseControls()
    {
        switchMainMenu.gameObject.SetActive(true);
        switchControlMenu.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
