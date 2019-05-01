using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level 1-1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level 1-2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level 1-3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("final forest level 1-4");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
