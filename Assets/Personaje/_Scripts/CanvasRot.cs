using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRot : MonoBehaviour
{
    public float animationSpeed = 1.0f; // Velocidad de la animación
    public float animationHeight = 1.0f; // Altura de la animación

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Mantén el canvas mirando hacia la cámara
        transform.forward = Camera.main.transform.forward;

        // Crea una animación suave de subida y bajada usando la función seno
        float yOffset = Mathf.Sin(Time.time * animationSpeed) * animationHeight;
        transform.position = originalPosition + new Vector3(0f, yOffset, 0f);
    }
}

