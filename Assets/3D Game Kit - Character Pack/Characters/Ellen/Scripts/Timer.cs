using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyCharacter;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    
    private float messageDuration = 5.0f;
    public TextMeshProUGUI introTMPro;
    public CharacterController jugador;
    public MiniMapComponent miniMapComponent;
    public GameObject miniMapa;
    public MenuPausa menu;
    public GameObject basura;
    public GameObject contenedores;
    public GameObject canvasPlayer;
    public GameObject zona; 
    public GameObject misiones;
    
    // Start is called before the first frame update
    void Start()
    {
        jugador = FindObjectOfType<CharacterController>();
        miniMapComponent = FindObjectOfType<MiniMapComponent>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if(timer <= 100 && timer >= 99)
        {
            jugador.enabled = false;
        }
       
        if(timer <= 97 && timer >= 96)
        {
            
            MostrarMensaje("Que bueno tenerte aquí, nuestro parque está en caos y necesitamos de tú ayuda.");
        }

        if(timer <= 93 && timer >= 92)
        {
            MostrarMensaje("Hemos sido azotados por una ola gigante de contaminación.");
        }

        if(timer <= 89 && timer >= 88)
        {   
            MostrarMensaje("Muchos turistas han estado visitando esta zona y lo han llenado de basura.");
        }
        
        if(timer <= 85 && timer >= 84)
        {   
            MostrarMensaje("Por lo que es importante limpiarlo para devolverle la vida este lugar.");
        }

        if(timer <= 81 && timer >= 80)
        {   
            MostrarMensaje("Y que vuelva a ser ese lugar hermoso que siempre ha sido...");
        }

        if(timer <= 77 && timer >= 76)
        {   
            MostrarMensaje("Tú labor es muy sencilla, recoger la basura que se encuentra tirada a lo largo y ancho del parque.");
        }

        if(timer <= 73 && timer >= 72)
        {   
            MostrarMensaje("Y después recuperar zonas verdes que se han perdido a causa de la deforestación.");
        }

        if(timer <= 69 && timer >= 68)
        {   
            MostrarMensaje("Por suerte, contamos con esta herramienta que nos ayudará a ubicar de manera rápida todos los objetos.");
            miniMapa.SetActive(true);
            miniMapComponent.enabled = true;
            //menu.enabled = true; 
        }

        if(timer <= 65 && timer >= 64)
        {   
            MostrarMensaje("La basura esta por todas partes como puedes notar...");
            basura.SetActive(true);
        }

        if(timer <= 61 && timer >= 60)
        {   
            MostrarMensaje("Pero no es problema, ya que tenemos contenedores de basura que nos ayudarán en la recolección.");
            contenedores.SetActive(true);
        }

        if(timer <= 57 && timer >= 56)
        {   
            MostrarMensaje("¿Preparado para la aventura?");
            
        }

        if(timer <= 53 && timer >= 52)
        {   
            MostrarMensaje("Empiezas en 3...");
            
        }

        if(timer <= 51 && timer >= 50)
        {   
            MostrarMensaje("2...");
            
        }

        if(timer <= 49 && timer >= 48)
        {   
            MostrarMensaje("1...");
            
        }

        if(timer <= 47 && timer >= 46)
        {   
            MostrarMensaje("¡Ahora! Empieza a recoger la basura.");
            canvasPlayer.SetActive(true);
            jugador.enabled = true;
            zona.SetActive(true);
            misiones.SetActive(true);
        }

        if(timer <= 43 && timer >= 42)
        {   
            MostrarMensaje("");
        }

        
    }
    private IEnumerator LimpiarMensaje()
    {
        yield return new WaitForSeconds(messageDuration);
        MostrarMensaje(""); 
    }

    public void MostrarMensaje(string mensaje)
    {
        introTMPro.text = mensaje;
    }
}
