using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cinematicas : MonoBehaviour
{
    private float timer;
    public int nivel;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            switch (nivel)
            {
                case 1:  SceneManager.LoadScene(3);
                    break;
                case 2:  SceneManager.LoadScene(5);
                    break;
                case 3:  SceneManager.LoadScene(0);
                    break;
                default:
                    break;
            }
            
        }
    }
}
