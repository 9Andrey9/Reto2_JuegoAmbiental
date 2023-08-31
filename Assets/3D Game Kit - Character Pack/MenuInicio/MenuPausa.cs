using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    public GameObject items;
    public GameObject console;
    private bool menuOn;
    public Animator ani;

    void Update()
    {
    
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            menuOn = !menuOn;
        }

        if (menuOn)
        {
            PonerPausa();
        }
        else
        {
            QuitarPausar();
        }
    }

    public void PonerPausa()
    {
        
        menuDePausa.SetActive(true);
        items.SetActive(false);
        console.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

    }

    public void QuitarPausar()
    {
        
        menuDePausa.SetActive(false);
        items.SetActive(true);
        console.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        

    }
}
