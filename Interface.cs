using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public static bool inicio = false;
    [SerializeField] GameObject MInicio;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (inicio)
        {
            Debug.Log("gg");
            Time.timeScale = 1f;
            MInicio.SetActive(false);
        }
    }
}
