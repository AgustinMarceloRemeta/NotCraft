using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enderman : MonoBehaviour
{
    Vector3 positionInicial;
    public float rangoTp;
    public GameObject Cubo, mano;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        positionInicial = transform.position;
        InvokeRepeating("Tp", 0f,velocity);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Tp()
    {
        float random = Random.Range(-rangoTp, rangoTp);
        transform.position = positionInicial + new Vector3(random, 0, 0);
        Instantiate(Cubo,mano.transform);
        
    }
    
}
