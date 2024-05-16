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

    public GameObject piedra;
    void Start()
    {
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
                }
                else if (!Input.GetKey(KeyCode.A))
                {
                    direccionDeMovimiento = 1;
                }
                else { direccionDeMovimiento = -1; }

                Vector2 movimiento = new Vector2
                    (transform.position.x + (velocidadDeMovimiento * direccionDeMovimiento * boost * Time.deltaTime),
                    transform.position.y);

                transform.position = movimiento;
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
            GameObject.Instantiate(piedra, transform.position,Quaternion.identity);
        }
    }

}
