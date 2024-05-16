using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWay : MonoBehaviour
{
    public GameObject collider;

    private void Start()
    {
        collider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            collider.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            collider.SetActive(false);
        }
    }
}
