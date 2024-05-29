using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour
{
    public int fuerza;
    Rigidbody2D rb;
    public int da�o;
    void Start()
    {
        GameObject camilo = GameObject.Find("Camilo");
        Vector2 direccion = new Vector2(camilo.transform.position.x - transform.position.x, camilo.transform.position.y  -transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        direccion.y += 2f;
        rb.AddForce(direccion*fuerza); //Revisa para donde mira camilo
        Destroy(gameObject, 2f); //Se destruye en 2 segundos
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            Debug.Log(collision);
            collision.GetComponent<Salud>().CambiarSalud(da�o);
            Destroy(gameObject);
        }
    }

}
