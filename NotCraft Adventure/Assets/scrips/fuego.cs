using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    ControlJugador controlJugador;
    int rapidez = 1;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        controlJugador = FindObjectOfType<ControlJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * rapidez * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("piedra")== true) Destroy(fire);
        if (other.gameObject.CompareTag("jugador") == true)
        {
            Destroy(fire);
            controlJugador.PierdeVida();
        }
    }
}
