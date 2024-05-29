using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectilpickable : MonoBehaviour
{
    Almacenamiento proyectil;
    public int cantidad;

    private void Start()
    {
        proyectil = GameObject.Find("Camilo").GetComponent<Almacenamiento>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        proyectil.CambiarProyectiles(cantidad);
        Destroy(gameObject);
    }
}
