using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlJugador : MonoBehaviour
{
   
    public GameObject Jugador;
    //animador
    public Animator anim;
    public Animator dragona;
    public LayerMask capaPiso;
    public float magnitudSalto;
    public CapsuleCollider2D col;
    private Rigidbody2D rigidbody2d;
    public bool Camara = false;
    public float fuerza = 0.1f;
    //vida
    public GameObject cora1Ubi, cora2Ubi, cora3Ubi, cora4Ubi, cora5Ubi;
    public GameObject cora1, cora2, cora3, cora4, cora5;
    private int vida;
    public GameObject SonidoMuerte;
    public GameObject Zombie;
    private float EjeX;
    private float Ejey;
    public int Nivel = 1;
    bool paso = false;
    public DisparoFuego disparofuego;
    public Settings settings;
    public GameObject[] corazones;
    private bool EstaEnPiso;


    void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
        if (Nivel == 1) vida = 5;
        else if (!(Nivel == 1))
        {
            if (settings.dificultad == "easy") vida = 5;
            if (settings.dificultad == "hard" || settings.dificultad == "hardcore") vida = PlayerPrefs.GetInt("vida");
        }
        Spawncorazones();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        //caminar =  Walk();

        float horizontal = Input.GetAxis("Horizontal") * fuerza;
        rigidbody2d.velocity= new Vector2(horizontal, rigidbody2d.velocity.y);

        if(Input.GetKey(KeyCode.A)|| Input.GetKey("left") ) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetKey(KeyCode.D)|| Input.GetKey("right")) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey("left shift"))
         {
            fuerza = 8f;
             Run();
        }
 
       if (!(Input.GetKey("left shift")))
         {
             fuerza = 6f;
            Walk();
        }

        if (horizontal == 0)
        {
            NoAnim();
        }       
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("instanciador") == true)
        {
            Camara = true;
        }
        if (other.gameObject.CompareTag("NoInsta") == true)
        {
            Camara = false;
        }
        if (!paso && other.gameObject.CompareTag("MuerteLenta") == true)
        {
            InvokeRepeating("PierdeVida", 0, 1.0f);
            paso = true;
        }
        if (other.gameObject.CompareTag("BajaVida") == true) 
        {
            PierdeVida();
        }
        if (other.gameObject.CompareTag("cambionivel") == true)
        {
            cambioLevel();
        }
        if (other.gameObject.CompareTag("dragona") == true)
        {
            dragona.SetBool("Accion", true);
            disparofuego.disparo=true;
        }
        if (other.gameObject.CompareTag("dragona2") == true)
        {
            dragona.SetBool("Accion2", true);
            disparofuego.disparo=false;
        }
    }

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down,0.1f, LayerMask.GetMask("piso")))
            EstaEnPiso = true;
        else EstaEnPiso = false;

        if (EstaEnPiso) {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
         }
        //muerte
        if (vida == 0)
        {
            Invoke("Muerte", 1.0f);
        }
        PlayerPrefs.SetInt("vida", vida);
    }

    private void Jump()
    {
        rigidbody2d.AddForce(Vector2.up*magnitudSalto);
    }



    public void PierdeVida()
    {
        switch (vida)
        {
            case 5:
                Destroy(cora1);
              Instantiate(SonidoMuerte, Jugador.transform.position, Quaternion.identity); 
                break;
            case 4:
                Destroy(cora2);
                Instantiate(SonidoMuerte, Jugador.transform.position, Quaternion.identity);
                break;
            case 3:
                Destroy(cora3);
                Instantiate(SonidoMuerte, Jugador.transform.position, Quaternion.identity);
                break;
            case 2:
                Destroy(cora4);
                Instantiate(SonidoMuerte, Jugador.transform.position, Quaternion.identity);
                break;
            case 1:
                Destroy(cora5);
                Instantiate(SonidoMuerte, Jugador.transform.position, Quaternion.identity);
                break;               
        }
        vida--;
        if (vida < 0) vida = 0;
    }

    public void Muerte()
    {
     if(settings.dificultad == "easy"|| settings.dificultad == "hard")   
            switch (Nivel)
        {
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(3);
                break;
            case 3:
                SceneManager.LoadScene(5);
                break;
            default:
                break;
        }
        if (settings.dificultad == "hardcore") SceneManager.LoadScene(1);
    }
 
    public void Run()
    {
        anim.SetBool("ZombieWalk", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("IdleStill", false);
        anim.SetBool("Swim", false);
        anim.SetBool("SitandTalk", false);
        anim.SetBool("SitandLook", false);
        anim.SetBool("SitStill", false);
        anim.SetBool("RideAnimalStill", false);
        anim.SetBool("RideAnimalMoving", false);
        anim.SetBool("HoldBow", false);
        anim.SetBool("HoldShoot", false);

        anim.SetBool("Run", true);
    }

    public void Walk()
    {
        anim.SetBool("ZombieWalk", false);
        anim.SetBool("Run", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("IdleStill", false);
        anim.SetBool("Swim", false);
        anim.SetBool("SitandTalk", false);
        anim.SetBool("SitandLook", false);
        anim.SetBool("SitStill", false);
        anim.SetBool("RideAnimalStill", false);
        anim.SetBool("RideAnimalMoving", false);
        anim.SetBool("HoldBow", false);
        anim.SetBool("HoldShoot", false);

        anim.SetBool("Walk", true);
    }

    public void NoAnim()
    {
        anim.SetBool("ZombieWalk", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("IdleStill", false);
        anim.SetBool("Swim", false);
        anim.SetBool("SitandTalk", false);
        anim.SetBool("SitandLook", false);
        anim.SetBool("SitStill", false);
        anim.SetBool("RideAnimalStill", false);
        anim.SetBool("RideAnimalMoving", false);
        anim.SetBool("HoldBow", false);
        anim.SetBool("HoldShoot", false);

        anim.SetBool("Run", false);
    }

    public void cambioLevel()
    {
        switch (Nivel)
        {
            case 1: SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(4);
                break;
            case 3:
                SceneManager.LoadScene(6);
                break;
            default:
                break;
        }
    }

    public void Spawncorazones() 
    {
        
        for (int i = 0; i < vida; i++)
        {
            switch (i)
            {
                case 0:
                    {
                        cora5 = Instantiate(corazones[i], cora5Ubi.transform.position, Quaternion.identity);
                        cora5.transform.SetParent(cora5Ubi.transform);
                    }
                    break;
                case 1:
                    {
                        cora4 = Instantiate(corazones[i], cora4Ubi.transform.position, Quaternion.identity);
                        cora4.transform.SetParent(cora4Ubi.transform);

                    }
                    break;
                case 2:
                    {
                        cora3 = Instantiate(corazones[i], cora3Ubi.transform.position, Quaternion.identity);
                        cora3.transform.SetParent(cora3Ubi.transform);
                    }
                    break;
                case 3:
                    {
                        cora2 = Instantiate(corazones[i], cora2Ubi.transform.position, Quaternion.identity);
                        cora2.transform.SetParent(cora2Ubi.transform);
                    }
                    break;
                case 4:
                    {
                        cora1 = Instantiate(corazones[i], cora1Ubi.transform.position, Quaternion.identity);
                        cora1.transform.SetParent(cora1Ubi.transform);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    }
    
