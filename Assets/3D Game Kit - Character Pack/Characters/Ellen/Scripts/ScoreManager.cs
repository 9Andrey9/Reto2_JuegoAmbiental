using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int puntos = 0;
    private float timer = 100;
    private bool isClearingMessage = false;
    public GameObject basura;
    public GameObject zona;
    public GameObject humo;
    public TextMeshProUGUI mensajeText;
    private bool isAnimating = false;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = scoreText.transform.localScale;
    }

    public void SumarPuntos(int cantidadPuntos)
    {
        puntos += cantidadPuntos;
        scoreText.text = puntos.ToString();

        if (!isAnimating)
        {
            StartCoroutine(ScaleAnimation());
        }
    }

    private IEnumerator ScaleAnimation()
    {
        isAnimating = true;

        float scaleFactor = 1.2f;
        float duration = 0.2f;
        Vector3 targetScale = originalScale * scaleFactor;

        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            scoreText.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            scoreText.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        isAnimating = false;
    }

    private void Update()
    {
        
        if (puntos == 40)
        {
            timer -= Time.deltaTime;
            Destroy(basura);
            Destroy(zona);
            Destroy(humo);
            MostrarMensaje("Bien hecho, has limpiado correctamente todo el parque.");
        
            
        }

        if (timer <= 95)
        {
            MostrarMensaje("");
        }
    }

    public void MostrarMensaje(string mensaje)
    {
        mensajeText.text = mensaje;
    }
}
