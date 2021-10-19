using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text TextoTimer;
    public float Tiempo = 10f;

    void Start()
    {
        TextoTimer.text = "Tiempo restante:" + Tiempo;
        


    }

    void Update()
    {
        if (Tiempo > 0)
        {
            Tiempo -= Time.deltaTime;
        }
        TextoTimer.text = "Tiempo restante:" + Tiempo.ToString("f2");

        if (Tiempo <= 0)
        {
            SceneManager.LoadScene(0);
        }
 
    }
}
