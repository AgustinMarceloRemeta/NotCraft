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
        LargarFuego();

    }

    private void LargarFuego()
    {
        bool puede = false;
        float random;
        timer = timer-1 * Time.deltaTime;

        if(timer<= 0) puede = true;
        if (puede)
        {
            random= Random.Range(-135,-45);
            Quaternion rotacion = Quaternion.Euler(new Vector3(0, 0, random));
            transform.rotation = rotacion;           

            GameObject pro = Instantiate(fuego, transform.position, transform.rotation);            
            timer = 2f;
            puede = false;
        }
        
    }
}
