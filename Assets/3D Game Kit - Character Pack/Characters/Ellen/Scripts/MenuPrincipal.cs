using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuPrincipal : MonoBehaviour
{


    public void EscenaJuego()
    {
        SceneManager.LoadScene("Reto2");
    }

    public void Salir()
    {
        Application.Quit();
    }



    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag = "personaje")
        {
            SceneManager.LoadScene("Game1");
        }
    }*/
}
