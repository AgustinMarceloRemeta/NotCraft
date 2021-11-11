using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajita : MonoBehaviour
{
    public GameObject Cubo;
    private ControlJugador controlJugador;
    bool toco = false;

    void Start()
    {
        controlJugador = FindObjectOfType<ControlJugador>();      
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("piso")) Destroy(Cubo);
        if (other.gameObject.CompareTag("jugador")&& !toco)
        {
            toco = true;
            Destroy(Cubo);
            controlJugador.PierdeVida();                
        }
        }
}

