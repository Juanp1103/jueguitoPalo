using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almacenamiento : MonoBehaviour
{
    public int proyectiles;
    public int proyectilInicial;
    PlayerController Camilo;
    bool puedeDisp;

    // Start is called before the first frame update
    void Start()
    {
        puedeDisp = true;
        proyectiles = proyectilInicial;
        Camilo = GetComponent<PlayerController>();
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
    // Update is called once per frame
    void Update()
    {
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
