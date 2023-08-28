using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTerreno : MonoBehaviour
{
    public GameObject canvas;
   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("personaje"))
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("personaje"))
        {
            canvas.SetActive(false);
        }
    }


}
