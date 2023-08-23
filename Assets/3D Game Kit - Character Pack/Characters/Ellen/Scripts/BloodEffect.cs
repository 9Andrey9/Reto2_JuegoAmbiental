using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{

    public Image bloodEffectImage;

    private float r;
    private float g;
    private float b;
    private float a;

    

    // Start is called before the first frame update
    void Start()
    {
        r=bloodEffectImage.color.r;
        g=bloodEffectImage.color.g;
        b=bloodEffectImage.color.b;
        a=bloodEffectImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {

        
        a -= 0.07f;

        a = Mathf.Clamp(a, 0, 1f);

        ChangeColor();

    }
    
    private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Danio")
            {
              a += 0.8f;  
            }

            if(other.tag == "Danio1")
            {
              a += 0.8f;  
            }
            
        }


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "arma")
        {
          a+=0.01f; 
          
        }
    }*/

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        bloodEffectImage.color = c;
    }
}
