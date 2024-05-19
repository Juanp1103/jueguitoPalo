using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    GameObject jugador;
    public float distanciaParaDisparar;
    public GameObject[] proyectil;
    public float cooldownDisparo;
    float timerCooldown, timerMov;
    bool puedeDisp;
    public float velocidadDeMovimiento;
    int direccion;
    Animator animator;
    SpriteRenderer sr;
    GameObject camilo;

    private void Start()
    {
        camilo = GameObject.Find("Camilo");
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jugador = GameObject.Find("Camilo");
        puedeDisp = true;
    }

    private void Update()
    {
       if(DistanciaAlJugador() > distanciaParaDisparar)
        {
            //Mover
            if(timerMov > 0)
            {
                timerMov-=Time.deltaTime;
                if (direccion == 1)
                {
                    Mover(1); //Mover derecha
                    animator.SetBool("Caminando", true);
                    sr.flipX = false;
                    
                }
                else if (direccion == 2)
                {
                    animator.SetBool("Caminando", true);
                    sr.flipX = true;
                    Mover(-1); //Mover izquierda
                }
                else
                {
                    animator.SetBool("Caminando", false);
                    Mover(0); //Quieto
                }
            }
            else
            {
                direccion = Random.Range(0, 3);
                timerMov = Random.Range(2, 6);
                
            }
            
        }
        else
        {
            if(camilo.transform.position.x > transform.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }

            animator.SetBool("Caminando", false);
            //Disparar
            if (puedeDisp)
            {
                animator.SetBool("Lanzando", true);
                int objeto = Random.Range(0, proyectil.Length);
                Instantiate(proyectil[objeto], transform.position, Quaternion.identity);
                timerCooldown = cooldownDisparo;
                puedeDisp = false;
            }
            else
            {
                animator.SetBool("Lanzando", false);
                timerCooldown -= Time.deltaTime;
                if(timerCooldown < 0)
                {
                    puedeDisp = true;
                }
            }

        }
    }

    public float DistanciaAlJugador()
    {
        float distancia;

        distancia = Mathf.Sqrt(Mathf.Pow(transform.position.x - jugador.transform.position.x, 2)
                             + Mathf.Pow(transform.position.y - jugador.transform.position.y, 2));

        return distancia;
    }

    public void Mover(int direccion)
    {
        transform.position = new Vector2(transform.position.x + direccion * Time.deltaTime * velocidadDeMovimiento,
                                         transform.position.y);
    }
}
