using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    public GameObject menuDerrota;
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        Debug.Log("Loading Game...");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}
