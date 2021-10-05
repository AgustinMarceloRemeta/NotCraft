using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie4 : MonoBehaviour

{
	public Animator anim;
	bool IrDerecha = false;
	int rapidez = 1;


	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		ZombieWalk();
		{
			if (transform.position.x >= 32.25)
			{
				IrDerecha = true;
			}
			if (transform.position.x <= 28.62)
			{
				IrDerecha = false;
			}

			if (IrDerecha)
			{
				derecha();
			}
			else
			{
				izquierda();
			}

		}
	}

		void derecha()
		{
		transform.position += transform.right * rapidez * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, 180, 0);
	}

		void izquierda()
		{
		transform.position += transform.right * rapidez * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, 0, 0);
		
	}


		void ZombieAttack()
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
		anim.SetBool("Walk", false);

		anim.SetTrigger("ZombieAttack");
	}

	public void ZombieWalk()
	{
		anim.SetBool("SitandTalk", false);
		anim.SetBool("Swim", false);
		anim.SetBool("Idle1", false);
		anim.SetBool("Run", false);
		anim.SetBool("Walk", false);
		anim.SetBool("SitandLook", false);
		anim.SetBool("SitStill", false);

		anim.SetBool("IdleStill", false);
		anim.SetBool("RideAnimalStill", false);
		anim.SetBool("RideAnimalMoving", false);

		anim.SetBool("HoldBow", false);

		anim.SetBool("HoldShoot", false);

		anim.SetBool("ZombieWalk", true);
	}
}