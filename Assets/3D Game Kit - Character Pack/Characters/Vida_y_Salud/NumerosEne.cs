using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumerosEne : MonoBehaviour
{
    public Text numero;
    public float velocidadAscendente;
    public float tiempoVida;
    Transform t;

    public void Inicializar(int _numero)
    {
        //t = GameObject.FindNameObjetcWithTag("personaje").transform;
        t = Camera.main.transform;
        numero.text = _numero.ToString();
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {

        if(t != null)
        {
        transform.LookAt(t.position);
        transform.position += Vector3.up * velocidadAscendente * Time.deltaTime;
        }
    }
}
