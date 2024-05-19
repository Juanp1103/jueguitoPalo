using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float boost;
    public LayerMask suelo;
    public Transform checkSuelo;
    float radioDelCheckSuelo = 0.2f;
    bool puedeMoverse, puedeSaltar, tocandoSuelo;
    public float velocidadDeMovimiento, fuerzaDeSalto;
    public int direccionDeMovimiento;
    Rigidbody2D rb;
    float cooldDownDeBoost;
    Animator animator;
    SpriteRenderer sr;

    public GameObject piedra;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boost = 1;
        puedeMoverse = true; puedeSaltar = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
        Saltar();
        TirarPiedra();

        if(direccionDeMovimiento == -1)
        {
            sr.flipX = true;
        }
        else { sr.flipX=false;}

        if (!tocandoSuelo)
        {
            animator.SetBool("Caminando", false);
            animator.SetBool("Saltando", true);
        }
        else
        {
            animator.SetBool("Saltando", false);
        }


        if(cooldDownDeBoost > 0)
        {
            cooldDownDeBoost -= Time.deltaTime;
        }
        else
        {
            boost = 1;
        }

        
    }

    public void Moverse()
    {
        if (puedeMoverse)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                {
                    direccionDeMovimiento = 0;
                    animator.SetBool("Caminando", false);
                }
                else if (!Input.GetKey(KeyCode.A))
                {
                    if (tocandoSuelo)
                    {
                        animator.SetBool("Caminando", true);
                    }
                    direccionDeMovimiento = 1;
                }
                else 
                { 
                    direccionDeMovimiento = -1; 
                    animator.SetBool("Caminando", true); 
                }

                Vector2 movimiento = new Vector2
                    (transform.position.x + (velocidadDeMovimiento * direccionDeMovimiento * boost * Time.deltaTime),
                    transform.position.y);

                transform.position = movimiento;
            }
            else
            {
                animator.SetBool("Caminando", false);
            }
        }
    }

    public void Saltar()
    {
        tocandoSuelo = Physics2D.OverlapCircle(checkSuelo.position, radioDelCheckSuelo, suelo);
        if (puedeSaltar && tocandoSuelo)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaDeSalto);
                
            }
            
            
        }

    }

    public void CambiarVelocidad(float cantidad, float tiempo)
    {
        if (cantidad > 0) 
        {
            boost = cantidad;
            cooldDownDeBoost = tiempo;
        }

    }
    
    public void TirarPiedra()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("Lanzando",true);
            GameObject.Instantiate(piedra, transform.position,Quaternion.identity);
        }
        else
        {
            animator.SetBool("Lanzando", false);
        }
    }

}
