using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGameButton;
    public Button LoadGameButton;
    public Button OptionsButton;
    public Button ExitButton;

    public void StartGame()
    {
       //SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
       
    }
    public void Options()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
