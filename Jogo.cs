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

    private int sorteado = 0;
    public bool instanciar = true;
    public static bool fogo = false;

    // Update is called once per frame
    void Update()
    {
        if (instanciar)
        {
            instanciar = false;
            Invoke("InstanciaColetavel", 3);
            // InstanciaColetavel();
        }
        if (fogo)
        {
            fogoPira.SetActive(true);
            Invoke("Pausa", 3);
            

        }
    }
    private void Pausa()
    {
        Time.timeScale = 0f;
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
}
