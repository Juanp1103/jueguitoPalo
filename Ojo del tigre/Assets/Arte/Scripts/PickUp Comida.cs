using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComida : MonoBehaviour
{
    PlayerController controller;
    public float cantidad, coolDown;

    private void Start()
    {
        controller = GameObject.Find("Camilo").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        controller.CambiarVelocidad(cantidad, coolDown);
        Destroy(gameObject);
    }
}
