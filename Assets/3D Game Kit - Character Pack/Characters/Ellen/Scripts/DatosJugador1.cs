using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador1 : MonoBehaviour
{
    public int damage = 50;
    public int vidaEnemigo;
    public Animator anim;
    public Slider BarraVidaEnemigo;

    public int cronometro;
    public Enemigo enemigoChomper, enemigoGrenadier, BossIntro;
    public GameObject SliderVida;
    public GameObject Monedas;
    public GameObject Puntos;
    public GameObject Minimap;
    public GameObject Vehiculo;
    public GameObject Canvas;
    public GameObject armas;
    public GameObject Slot;



    





    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Danio")
        {
           anim.SetBool("damage", true);
        }


        if(other.tag == "arma")
        {
           //animEnemigo.SetBool("damage", true);
           vidaEnemigo = vidaEnemigo - damage;


            if(vidaEnemigo == 0)
            {
                
                anim.SetBool("death", true);
                cronometro++;

                StartCoroutine(DelayedDead(anim.GetCurrentAnimatorStateInfo(0).length));
                enemigoChomper.enabled = false;
                enemigoGrenadier.enabled = false;
                BossIntro.enabled = false;
                
                
                Canvas.SetActive(false);
                armas.SetActive(false);
                


            IEnumerator DelayedDead(float _delay = 7)
            {
                
                yield return new WaitForSeconds(_delay);
                Destroy(SliderVida);
                Destroy(Monedas);
                Destroy(Puntos);
                Destroy(Minimap);
                Destroy(Vehiculo);

                Slot.SetActive(false);
                Over.show();

   
            }



                //enemigo.enabled = false;
                
                
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Danio")
        {
            anim.SetBool("damage", false);
    
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Bala")
        {
           animEnemigo.SetBool("damage", false);
        }
    }*/

}