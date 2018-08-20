using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoH : MonoBehaviour
{
    public bool colidir;
    public bool irLadoNegativo = true;
    
    void Start()
    {
      
    }

    void Update()
    {

        if (colidir)
        {
            irLadoNegativo = !irLadoNegativo;
        }

        if (irLadoNegativo)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0));
            GetComponent<SpriteRenderer>().flipX = false;
            colidir = false;
        }

       else if (!irLadoNegativo)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0));
            GetComponent<SpriteRenderer>().flipX = true;
            colidir = false;
        }
        
        
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            colidir = true;
        }
        

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            colidir = false;
        }

    }
}
