using UnityEngine;
using UnityEngine.InputSystem;

public class Reforestacion : MonoBehaviour
{
    public Material newMaterial;
    public GameObject[] objectsToInstantiate;
    public string[] messages; 
    public int maxInstances = 5;

    private GameObject terrainToChange;
    private Recoger recogerMensaje;
    private GameObject[] instantiatedObjects;
    private int currentInstanceIndex = 0;
    private bool materialChanged = false;

    public AudioSource audio;

    public void Start()
    {
        recogerMensaje = GetComponent<Recoger>();
        instantiatedObjects = new GameObject[maxInstances];
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Terreno"))
        {
            terrainToChange = collision.gameObject;
            materialChanged = false; 
            currentInstanceIndex = 0; 
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Terreno"))
        {
            recogerMensaje.MostrarMensaje("");
        }
    }

    private void Update()
    {
        if (!materialChanged)
        {
            if (terrainToChange != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                Renderer renderer = terrainToChange.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = newMaterial;
                    recogerMensaje.MostrarMensaje("¡Terreno abonado! Listo para sembrar");
                    audio.Play();
                    materialChanged = true;
                }
            }
        }
        else if (materialChanged && currentInstanceIndex < maxInstances)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (currentInstanceIndex > 0 && instantiatedObjects[currentInstanceIndex - 1] != null)
                {
                    instantiatedObjects[currentInstanceIndex - 1].SetActive(false);
                }

                Vector3 center = terrainToChange.transform.position;
                instantiatedObjects[currentInstanceIndex] = Instantiate(objectsToInstantiate[currentInstanceIndex], center, Quaternion.identity);

                recogerMensaje.MostrarMensaje(messages[currentInstanceIndex]);

                audio.Play();
                currentInstanceIndex++;
            }
        }
    }
}
