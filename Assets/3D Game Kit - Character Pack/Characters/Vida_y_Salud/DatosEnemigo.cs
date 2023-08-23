using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosEnemigo : MonoBehaviour
{
    public int damage = 50;
    public int vidaEnemigo;

    private Animator animEnemigo;

    public Slider BarraVidaEnemigo;

    public GameObject damageText;

    public GameObject arbol;

    public GameObject villano;

    public Enemigo enemigo;

    public GameObject antorchas;//////////////

    public DiaNoche dianoche;

    public GameObject TextFinal;

    public GameObject TriggerAbrirJaulas;
    
    public GameObject TriggerAbrirJaulas1;


    public Navmesh nav;

    public GameObject CanvasPausa;

    public GameObject danio;
    




    void Start()
    {
        animEnemigo = GetComponent<Animator>();
    }


    private void Update()
    {
        BarraVidaEnemigo.value = vidaEnemigo;
        
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala")
        {
    
           vidaEnemigo = vidaEnemigo - damage;
           DanoIndicador indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DanoIndicador>();
           indicator.SetDamageText(damage); 

            if(vidaEnemigo == 0)
            {
                
                animEnemigo.SetBool("death", true);

                StartCoroutine(DelayedDead(animEnemigo.GetCurrentAnimatorStateInfo(0).length));
                enemigo.enabled = false;
                nav.enabled = false;
                danio.SetActive(false);

                
                

            IEnumerator DelayedDead(float _delay = 7)
            {
                
                yield return new WaitForSeconds(_delay);
                
                Destroy(villano);
                //Destroy(villano);
                arbol.SetActive(true);
                arbol.transform.position = gameObject.transform.position;

                TextFinal.SetActive(true);
                Destroy(TextFinal, 10f);
                TriggerAbrirJaulas.SetActive(true);
                TriggerAbrirJaulas1.SetActive(true);
                dianoche.min = 360f;
                
                
                antorchas.SetActive(false);
                CanvasPausa.SetActive(false);
                
            }
                
    
            }
        }
    }

   
    
}
