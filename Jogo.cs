using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Jogo : MonoBehaviour
{
    [SerializeField] GameObject coletavel;
    [SerializeField] Transform[] coordenadas = new Transform[5];
    [SerializeField] GameObject fogoPira;
    [SerializeField] GameObject fogoTocha;
    private float temporizador;
    private bool contaTempo = true;
    [SerializeField] Text mostrador;

    private int sorteado = 0;
    public bool instanciar = true;
    public static bool fogo = false;
    public static bool coleta = false;
    public GameObject gameOverScreen;
    public GameObject youWinMenu;
    private bool win = false;

    private void Start()
    {

        Vector3 DefaultScale = new Vector3(40f, 40f, 40f);
        fogoTocha.transform.localScale = DefaultScale;
    }
    // Update is called once per frame
    void Update()
    {
        contadorTemporal();
        if (instanciar)
        {
            instanciar = false;
            InstanciaColetavel();
        }
        if (fogo)
        {
            win = true;
            fogoPira.SetActive(true);
             Invoke("Pausa", 3);
            //Time.timeScale = 0f;

        }

        Tocha();

    }
    private void Pausa()
    
    {
        if(win == true)
        {
            Time.timeScale = 0f;
            youWinMenu.SetActive(true);
        } 
        else
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
     
    }

    private void Tocha()
    {
        
        fogoTocha.transform.localScale += new Vector3(-0.01f, -0.01f, -0.01f);
        if (fogoTocha.transform.localScale.x <= 0)
        {
            Pausa();
            //Menu Derrota    
            Debug.Log("Lost");
            fogoTocha.transform.localScale += new Vector3(40f, 40f, 40f);

        }

        if (coleta)
        {
            coleta = false;
            fogoTocha.transform.localScale += new Vector3(20f, 20f, 20f);
        }
    } 
    void InstanciaColetavel()
    {
        sorteado = sorteio(0, 4);
        Instantiate(coletavel, coordenadas[sorteado].position, Quaternion.identity);
    }

    int sorteio(int minimo, int maximo)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        return minimo + (sorteado - minimo + Random.Range(1, maximo - minimo)) % (maximo - minimo);

    }

    void contadorTemporal() { 


        temporizador = fogoTocha.transform.localScale.x;
        MostraTempo(temporizador);
        
        if (contaTempo)
        {
            if (temporizador > 0) { 
                temporizador = 0;
                contaTempo = false;
            }
        }
    }


    void MostraTempo(float relogio)
    {
        float minutos = Mathf.FloorToInt(relogio);
        //float segundos = Mathf.FloorToInt(relogio % 60);

        mostrador.text =  "Vida: " + minutos;
    }
}
