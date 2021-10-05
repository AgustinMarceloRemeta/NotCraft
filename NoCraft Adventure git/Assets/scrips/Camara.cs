using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Jugador;
    public ControlJugador CJ;



    void Update()
    {
        if(CJ.Camara){
            Vector3 position = transform.position;
            position.x = Jugador.transform.position.x;
            transform.position = position;
        }
    }
}
