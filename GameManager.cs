using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static bool gameover = false;
    public static bool win = false;
   // [SerializeField] GameObject inicio;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameover)
        //{
        //    Time.timeScale = 0f;
        //    painel.SetActive(true);
        //}
        //else if (win)
        //{
        //    Time.timeScale = 0f;
        //    painelW.SetActive(true);
        //}

    }
   public void Awake()
    {
       
        //Interface.inicio = true;
    }
  
    public void sairJogo()
    {
       // UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        //painel.SetActive(false);
        gameover = false;
        win = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
