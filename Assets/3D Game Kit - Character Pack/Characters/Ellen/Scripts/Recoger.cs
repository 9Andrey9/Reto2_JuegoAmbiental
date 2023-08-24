using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;

public class Recoger : MonoBehaviour
{
    public GameObject floatingCanvasPrefab; 
    private List<GameObject> activeFloatingCanvases = new List<GameObject>(); 
    private GameObject currentlyInteractingObject; 
    private AudioSource audioBotarBasura;
    public ScoreManager scoreManager;
    public AudioSource audioDing;

    //public GameObject inventarioFullText; 
    public TextMeshProUGUI mensajeTMPro;
    public GameObject basura;

    private int puntosGanados = 1;
    private int puntosActuales = 0;
    private int puntosMaximos = 5;

    void Start()
    {
        audioBotarBasura = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basura") && puntosActuales < puntosMaximos)
        {
            GameObject newFloatingCanvas = Instantiate(floatingCanvasPrefab);
            activeFloatingCanvases.Add(newFloatingCanvas);

            currentlyInteractingObject = other.gameObject;

            newFloatingCanvas.transform.SetParent(currentlyInteractingObject.transform, false);
        }

        if (other.CompareTag("Contenedor"))
        {
            audioBotarBasura.Play();
            puntosActuales = 0;
            MostrarMensaje("Basura depositada");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basura"))
        {
            GameObject canvasToDeactivate = activeFloatingCanvases.Find(canvas => canvas.transform.parent == other.transform);
            if (canvasToDeactivate != null)
            {
                canvasToDeactivate.SetActive(false);
                activeFloatingCanvases.Remove(canvasToDeactivate);
            }

            if (currentlyInteractingObject == other.gameObject)
            {
                currentlyInteractingObject = null;
            }
        }

        
    }

    private void Update()
    {
        if (currentlyInteractingObject != null && Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (puntosActuales < puntosMaximos)
            {
                puntosActuales += puntosGanados;
                scoreManager.SumarPuntos(puntosGanados); 
                Destroy(currentlyInteractingObject);
                currentlyInteractingObject = null;
                audioDing.Play();
            }
            if (puntosActuales == puntosMaximos)
            {
                MostrarMensaje("5/5 Inventario lleno !Deposita la basura en el contenedor más cercano!");
                
            }
        }

        if (puntosActuales == 40)
        {
            Destroy(basura);
        }
    }

    public void MostrarMensaje(string mensaje)
    {
        mensajeTMPro.text = mensaje;
        
    }

}
