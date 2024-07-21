using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlayMenu");
    }
    public void TurnOffSounds()
    {

    }
   /* public void QuitGame()
    {
        Application.Quit();
    } */
}
