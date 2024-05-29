using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int fuerza;
    Rigidbody2D rb;
    public int da�o;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(
            GameObject.Find("Camilo").GetComponent<PlayerController>().direccionDeMovimiento 
            * fuerza,150)); //Revisa para donde mira camilo
        Destroy(gameObject, 2f); //Se destruye en 2 segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Debug.Log("Da�o a enemigo");
            collision.GetComponent<Salud>().CambiarSalud(da�o);
            Destroy(gameObject);
        }
    }

}
