using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoFuego : MonoBehaviour
{
    public GameObject fuego;
    private float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0, 3f);

        LargarFuego();

    }

    private void LargarFuego()
    {
        bool puede = false;
       
        timer = timer-1 * Time.deltaTime;
        if(timer<= 0) puede = true;
        if (puede)
        {        
            GameObject pro = Instantiate(fuego, transform.position, transform.rotation);            
            timer = 2f;
            puede = false;
        }
        
    }
}
