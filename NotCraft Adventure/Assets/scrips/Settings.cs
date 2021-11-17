using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public string dificultad;
    // Start is called before the first frame update
    void Start()
    {
        dificultad = PlayerPrefs.GetString("Dificultad");
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("Dificultad", dificultad); 
        
    }
}
