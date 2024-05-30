using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almacenamiento : MonoBehaviour
{
    public int proyectiles;
    public int proyectilInicial;
    PlayerController Camilo;
    bool puedeDisp;
    public SpriteRenderer[] Botellas;

    // Start is called before the first frame update
    void Start()
    {
        puedeDisp = true;
        proyectiles = proyectilInicial;
        Camilo = GetComponent<PlayerController>();
        Botellas = GetComponent<SpriteRenderer[]>();
        cambiarContador();
    }

    public void CambiarProyectiles(int valor)
    {
        if (proyectiles - valor > proyectilInicial)
        {
            proyectiles = proyectilInicial;
        }
        else
        {
            proyectiles -= valor;
        }


    }
    public void cambiarContador()
    {
        for (int i = 0; i <= 15; i++)
        {
            Botellas[i].color = Color.clear;
        }
        Botellas[proyectiles].color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        cambiarContador();
        if (proyectiles > 0)
        {

            Camilo.TirarPiedra(true);
        }
        else
        {
            Camilo.TirarPiedra(false);
        } 
    }
}
