using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{

    public Transform Ellen;
    private NavMeshAgent agente;
    private Enemigo enemigo;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        enemigo = GetComponent<Enemigo>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = Ellen.position;
        anim.SetBool("run", true);

        if(enemigo.atacando)
        {
            agente.enabled = false;
        }else
        {
            agente.enabled = true;
        }

    }

}
