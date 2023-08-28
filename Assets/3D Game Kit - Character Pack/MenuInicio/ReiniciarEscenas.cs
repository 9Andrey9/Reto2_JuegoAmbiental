using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Reintentar3()
    {
        SceneManager.LoadScene(3);
    }

    

    public void Salir()
    {
        Application.Quit();
    }
}
