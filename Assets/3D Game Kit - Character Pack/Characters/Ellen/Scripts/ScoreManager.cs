using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObject;
    public int puntos = 0;
    public float timer = 100;
    private bool isClearingMessage = false;
    public GameObject basura;
    public GameObject zona;
    public GameObject humo;
    public GameObject misionCompletada1;
    public GameObject check1Canvas;
    public GameObject flechaReforestacion;
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
            check1Canvas.SetActive(true);
            Destroy(basura);
            Destroy(zona);
            Destroy(humo);
            

            timer -= Time.deltaTime;
            if (timer <= 100 && timer >= 99)
            {
                MostrarMensaje("Bien hecho, has limpiado correctamente todo el parque.");
                Destroy(scoreTextObject);
            }

            if (timer <= 94 && timer >= 93)
            {
                MostrarMensaje("Es hora de empezar la reforestación, dirígite a donde marca la flecha roja");
                flechaReforestacion.SetActive(true);
            }

            if (timer <= 89 && timer >= 88)
            {
                MostrarMensaje("");
                misionCompletada1.SetActive(true);
            }

            if (timer <= 85 && timer >= 84)
            {
                misionCompletada1.SetActive(false);
                puntos = 0;
                
            }
            
            
        }
        
    }

    public void MostrarMensaje(string mensaje)
    {
        mensajeText.text = mensaje;
    }
}
