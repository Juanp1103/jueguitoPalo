using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoVertical : MonoBehaviour
{
    public float velocidadDeMovimeinto, tiempoParaCambiarDeDireccion;
    float timer;
    int direccion;


    private void Start()
    {
        direccion = 1;
        timer = tiempoParaCambiarDeDireccion;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * velocidadDeMovimeinto* Time.deltaTime * direccion);

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = tiempoParaCambiarDeDireccion;
            direccion *= -1;
        }
    }
}
