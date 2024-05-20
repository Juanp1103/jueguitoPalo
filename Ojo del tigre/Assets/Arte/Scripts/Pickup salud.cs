using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupsalud : MonoBehaviour
{
    Salud salud;
    public int cantidad;

    private void Start()
    {
        salud = GameObject.Find("Camilo").GetComponent<Salud>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        salud.CambiarSalud(cantidad);
        Destroy(gameObject);
    }
}
