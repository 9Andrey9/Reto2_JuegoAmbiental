using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedor : MonoBehaviour
{

    public ScoreManager manager;
    public GameObject canvas;

    private MiniMapComponent miniMap;
    // Start is called before the first frame update
    void Start()
    {
        miniMap = GetComponent<MiniMapComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.puntos == 40)
        {
            Destroy(canvas);
            miniMap.enabled = false;
        }
    }
}
