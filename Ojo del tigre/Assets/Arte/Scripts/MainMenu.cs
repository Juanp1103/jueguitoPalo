using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }
    public void Reglas()
    {
        SceneManager.LoadScene("Reglas");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Perdida()
    {
        SceneManager.LoadScene("Perdida");
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
