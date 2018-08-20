using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_m : MonoBehaviour
{

    private int i;
    private bool pulo,PULO = false;
    private bool andar = false;
    private bool voar = false;
    private bool nadar = false;
    private bool trampolim = false;
    private bool LUTA = false;
    float move, moveV;
    

    void Update()
    {

        if (nadar)
        {
            GetComponent<Animator>().SetBool("nadando", true);


            if (moveV != 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, moveV * Time.deltaTime), ForceMode2D.Impulse);

            }              
            

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10f * Time.deltaTime), ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("pulando", true);

        }

        if (!nadar)
        {
            GetComponent<Animator>().SetBool("nadando", false);

            if (PULO && pulo)//Pulo
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
                GetComponent<Animator>().SetBool("pulando", true);
                GetComponent<AudioSource>().Play();
                andar = false;
                PULO = false;
            }
            if (trampolim)//Pulo
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800));
                GetComponent<Animator>().SetBool("pulando", true);
                GetComponent<AudioSource>().Play();
                andar = false;
                trampolim = false;
            }

            if (PULO && !pulo)//Voar
            {
                GetComponent<Animator>().SetBool("voando", true);
                voar = true;
            }
        }



        if (move < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (andar)
            {
                GetComponent<Animator>().SetBool("caminhando", true);

            }
        }
        else if (move > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (andar)
            {
                GetComponent<Animator>().SetBool("caminhando", true);

            }
        }
        else if (move == 0)
        {
            GetComponent<Animator>().SetBool("caminhando", false);
        }

        if (!voar)
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(move * 10, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (voar)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * 10, -0.9f);
        }
        if (andar)
        {
            GetComponent<Animator>().SetBool("pulando", false);
            GetComponent<Animator>().SetBool("voando", false);
            voar = false;
        }

        if (LUTA)//Luta
        {
            GetComponent<Animator>().SetTrigger("lutando");

            Collider2D[] colliders = new Collider2D[3];
            transform.Find("area_luta").gameObject.GetComponent<Collider2D>()
              .OverlapCollider(new ContactFilter2D(), colliders);
            for (i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null && colliders[i].gameObject.tag == "monstro")
                {
                    Destroy(colliders[i].gameObject);
                }
            }
            LUTA = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "agua")
        {
            nadar = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "agua")
        {
            nadar = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            pulo = true;
            andar = true;
        }

        if (collision.gameObject.tag == "trampolim")
        {
            trampolim = true;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataforma")
        {
            pulo = false;
            andar = false;
        }

    }

    public void Luta()
    {
        LUTA = true;
    }

    public void Pular()
    {
        PULO = true;
    }

    public void Horizontal(int A)
    {
        move = A;
    }
    public void Vertical(int A)
    {
        moveV = A;
    }


}