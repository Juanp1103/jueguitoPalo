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

    private void Start()
    {
        jugador = GameObject.Find("Camilo");
        puedeDisp = true;
    }

    private void Update()
    {
       if(DistanciaAlJugador() > distanciaParaDisparar)
        {
            print(DistanciaAlJugador());
            //Mover
        }
        else
        {
            //Disparar
            if(puedeDisp)
            {
                int objeto = Random.Range(0, proyectil.Length);
                Instantiate(proyectil[objeto], transform.position, Quaternion.identity);
                timerCooldown = cooldownDisparo;
                puedeDisp = false;
            }
            else
            {
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
}
