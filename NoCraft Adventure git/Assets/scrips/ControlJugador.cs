using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlJugador : MonoBehaviour
{
   
    public GameObject Jugador;
    //animador
    public Animator anim;
    public LayerMask capaPiso;
    public float magnitudSalto;
    public CapsuleCollider col;
    private Rigidbody rb;
    public bool Camara = false;
    public float fuerza = 0.1f;
    //vida
    public GameObject cora1;
    public GameObject cora2;
    public GameObject cora3;
    public GameObject cora4;
    public GameObject cora5;
    public int vida = 5;
    public GameObject SonidoMuerte;
    public GameObject Zombie;
    

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(fuerza, 0, 0);
            Walk();
        }

        if (transform.position.x> -8.15)       
        { if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-fuerza, 0, 0);
                Walk();
            }
        }
        if (Input.GetKey("left shift"))
        {
            fuerza = 0.2f;
            Run();
        }

        if (!(Input.GetKey("left shift")))
        {
            fuerza = 0.1f;
        }

        if (!(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.D)))
        {
            NoAnim();
        }
        if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.D)))
            {
            NoAnim();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("instanciador") == true)
        {
            Camara = true;
        }
        if (other.gameObject.CompareTag("NoInsta") == true)
        {
            Camara = false;
        }
        if (other.gameObject.CompareTag("MuerteLenta") == true)
        {
            InvokeRepeating("PierdeVida", 0, 1.0f);
        }
        if (other.gameObject.CompareTag("BajaVida") == true) 
        {
            PierdeVida(); 
        }
        
    }

    private void Update()
    {
        if (EstaEnPiso()) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector3.up * magnitudSalto, ForceMode.Impulse);
            }
        }
        //muerte
        if (vida == 0)
        {
            InvokeRepeating("Muerte", 1.0f, 0);
        }
    }

    private bool EstaEnPiso()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
        col.bounds.min.y, col.bounds.center.z), col.radius * .9f, capaPiso);
    }

    private void PierdeVida()
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
        vida = vida - 1;
    }

    public void Muerte()
    {
        SceneManager.LoadScene("Nivel1");
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

    }

