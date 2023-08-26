using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DiaNoche : MonoBehaviour
{
    public float min, grados;
    public float timeSpeed = 1;
    public Light luna;
    public GameObject luces;

    void Update()
    {
        min += timeSpeed * Time.deltaTime;
        if(min >= 1440)
        {
            min = 0;
        }
        grados = min/4;
        this.transform.localEulerAngles = new Vector3(grados, -90f, 0f);
        if(grados >=180)
        {
            this.GetComponent<Light>().enabled = false;
            luna.enabled = true;
            luces.SetActive(true);
        }
        else 
        {
            this.GetComponent<Light>().enabled = true;
            luna.enabled = false; 
            luces.SetActive(false); 
        }
    }
}
