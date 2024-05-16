using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int fuerza;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(
            GameObject.Find("Camilo").GetComponent<PlayerController>().direccionDeMovimiento 
            * fuerza,150)); //Revisa para donde mira camilo
        Destroy(gameObject, 5f); //Se destruye en 5 segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("Daño a enemigo");
            Destroy(gameObject);
        }
    }

}
