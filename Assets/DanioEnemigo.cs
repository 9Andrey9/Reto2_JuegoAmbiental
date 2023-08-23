using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioEnemigo : MonoBehaviour
{

    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("walk", false);
    }
     private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemigo")){
            ani.SetBool("Attack", true);
        }
    }

    void Update()
    {
        
    }
    }

    
  
