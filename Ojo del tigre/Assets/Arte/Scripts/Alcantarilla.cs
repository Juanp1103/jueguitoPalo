using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcantarilla : MonoBehaviour
{
    GameObject controller;

    private MainMenu Menu;

    private void Start()
    {
        controller = GameObject.Find("Camilo");
        Menu = GameObject.Find("SceneManager").GetComponent<MainMenu>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            Menu.Perdida();
        }
    }

    private void Update()
    {
        
    }

}
