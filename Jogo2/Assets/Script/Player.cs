using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text TextVidas;
    public Text TextMoedas;
    public GameObject FimJogo;
    private int cont_vidas=1;
    private int cont_moedas=0;
   
    public GameObject last_checkpoint, first_checkpoint;

    void Start () {
        TextVidas.text = cont_vidas.ToString();
        TextMoedas.text = cont_moedas.ToString();
        FimJogo.SetActive(false);

    }
	

    void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "moeda")
        {
            Destroy(collision.gameObject);
            cont_moedas++;
            TextMoedas.text = cont_moedas.ToString();
        }

        if (collision.gameObject.tag == "vida")
        {
            Destroy(collision.gameObject);
            cont_vidas++;
            TextVidas.text = cont_vidas.ToString();
        }

        if (collision.gameObject.tag == "checkpoint1")
        {
            first_checkpoint = collision.gameObject;
        }
        if (collision.gameObject.tag == "checkpoint")
        {
            last_checkpoint = collision.gameObject;
        }

        if (collision.gameObject.tag == "chegada")
        {
            FimJogo.SetActive(true);
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "monstro")
        {
            cont_vidas--;
            Destroy(collision.gameObject);

            if (cont_vidas == 0)
            {
                transform.position = last_checkpoint.transform.position;
            }

            if (cont_vidas < 0)
            {
                transform.position = first_checkpoint.transform.position;
                cont_vidas = 0;
            }
            TextVidas.text = cont_vidas.ToString();
        }
        if ( collision.gameObject.tag == "pico")
        {
            cont_vidas--;

            if (cont_vidas == 0)
            {
                transform.position = last_checkpoint.transform.position;
            }

            if (cont_vidas < 0)
            {
                transform.position = first_checkpoint.transform.position;
                cont_vidas = 0;
            }
            TextVidas.text = cont_vidas.ToString();
        }

    }

  
}
