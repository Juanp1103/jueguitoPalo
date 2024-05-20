using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Salud : MonoBehaviour
{
    public int saludInicial;
    public int salud;
    SpriteRenderer sr;
    Camara camera;
    public bool jugador;
    private MainMenu Menu;
    private void Start()
    {
        salud = saludInicial;
        sr = GetComponent<SpriteRenderer>();
        camera = GameObject.Find("Main Camera").GetComponent<Camara>();
        Menu = GameObject.Find("SceneManager").GetComponent<MainMenu>();
    }

    public void CambiarSalud(int valor)
    {
        if(salud - valor > saludInicial)
        {
            salud = saludInicial;
        }
        else
        {
            salud -= valor;
        }

        if(valor < 0)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }

        Invoke("VolverAColorNormal", 0.1f);

        
    }

    public void VolverAColorNormal()
    {
        sr.color = Color.white;
    }

    private void Update()
    {
        if(salud <=  0)
        {
            Destroy(gameObject);
            camera.kill++;
            if (jugador == true)
            {
                Menu.Perdida();
            }
        }
    }
}
