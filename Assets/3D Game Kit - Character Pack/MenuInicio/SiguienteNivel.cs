using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SiguienteNivel : MonoBehaviour
{

    
    public float timer;
    public int nivel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 3 && timer >= 0)
        {
            SceneManager.LoadScene(nivel);

        }
    }
}
