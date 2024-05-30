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
    Boss bossK;
    public bool jugador;
    public bool boss;
    private MainMenu Menu;
    public SpriteRenderer[] Corazones;
    private void Start()
    {
        salud = saludInicial;
        sr = GetComponent<SpriteRenderer>();
        camera = GameObject.Find("Main Camera").GetComponent<Camara>();
        Menu = GameObject.Find("SceneManager").GetComponent<MainMenu>();
        bossK = GameObject.Find("boss").GetComponent <Boss>();
        Corazones = GetComponent<SpriteRenderer[]>();
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

    public void CambiarCorazon()
    {
        if (salud == 1)
        {
            Corazones[0].color = Color.white;
        }
        if (salud == 2)
        {
            Corazones[1].color = Color.white;
        }
        if (salud == 3)
        {
            Corazones[2].color = Color.white;
        }
        if (salud == 4)
        {
            Corazones[3].color = Color.white;
        }
        if (salud == 5)
        {
            Corazones[4].color = Color.white;
        }
        if (salud == 6)
        {
            Corazones[5].color = Color.white;
        }
        if (salud == 7)
        {
            Corazones[6].color = Color.white;
        }
        if (salud == 8)
        {
            Corazones[7].color = Color.white;
        }
        if (salud == 9)
        {
            Corazones[8].color = Color.white;
        }
        if (salud == 10)
        {
            Corazones[9].color = Color.white;
        }
        else
        {
            for (int i = salud; i <= 9 ; i++)
            {

            Corazones[i].color = Color.clear;
            }
        }

    }

    public void VolverAColorNormal()
    {
        sr.color = Color.white;
    }

    private void Update()
    {
        if (jugador == true)
        {
            CambiarCorazon();
        }
        if(salud <=  0)
        {
            Destroy(gameObject);
            camera.kill++;
            bossK.kill++;
            if (jugador == true)
            {
                Menu.Perdida();
            }
            if (boss == true)
            {
                Menu.Win();
            }
        }
    }
    
}
