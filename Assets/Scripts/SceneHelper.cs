using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OpenSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void OpenVersus()
    {
        SceneManager.LoadScene("Versus");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saindo do jogo!");
    }
}
