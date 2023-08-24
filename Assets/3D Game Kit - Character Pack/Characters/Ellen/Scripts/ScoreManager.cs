using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;   
    public int puntos = 0;
    public GameObject basura;
    public GameObject zona;

    public void SumarPuntos(int cantidadPuntos)
    {
        puntos += cantidadPuntos;
        scoreText.text = puntos.ToString();

    
    }

    private void Update()
    {
        if (puntos == 40)
        {
            Destroy(basura);
            Destroy(zona);
        }
    }

    
}
