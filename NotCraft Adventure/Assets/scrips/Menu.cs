using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu, opciones, Firtsdificultad, dificultad;
    public Settings settings;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadScene(string Nivel1)
    {
        SceneManager.LoadScene(1);
    }

    public void Opciones()
    {
        menu.SetActive(false);
        opciones.SetActive(true);
    }
    public void Cerrar()
    {
        Application.Quit();
    }

    public void atras1()
    {
        opciones.SetActive(false);
        menu.SetActive(true);
    }
    public void Dificultad()
    {
        opciones.SetActive(false);
        dificultad.SetActive(true);
    }
    public void atras2()
    {
        dificultad.SetActive(false);
        opciones.SetActive(true);
    }
    public void Easy()
    {
        settings.dificultad = "easy";
    }
    public void Hard()
    {
        settings.dificultad = "hard";
    }
    public void Hardcore()
    {
        settings.dificultad = "hardcore";
    }
    public void FirtsEasy()
    {
        settings.dificultad = "easy";
        Firtsdificultad.SetActive(false);
        menu.SetActive(true);
    }
    public void FirtsHard()
    {
        settings.dificultad = "hard";
        Firtsdificultad.SetActive(false);
        menu.SetActive(true);
    }
    public void FirtsHardcore()
    {
        settings.dificultad = "hardcore";
        Firtsdificultad.SetActive(false);
        menu.SetActive(true);
    }
}
