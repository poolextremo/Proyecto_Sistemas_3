using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        General.ValuesDefault();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void MenuGame()
    {
        SceneManager.LoadScene("MainMenu");
        General.ValuesDefault();
    }
}
