using UnityEngine;
using System.Collections;

public class Animation_Manager : MonoBehaviour {


	static Animator anim;
	private GameObject Player;
	private float dis;
	public static float health;
	private float damage;
	private AudioSource m_AudioSource;




	// Use this for initialization
	void Start()
	{
		m_AudioSource = GetComponent<AudioSource>();
	}
	void Awake ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator>();
		health = 100;
		damage = 50;
		m_AudioSource = GetComponent<AudioSource>();
	

		//anim.SetBool ("isWalking", false);
		//	anim.SetBool ("isRunning", false);

	}
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "Projectile") 
		{
			health -= damage;
			if (health <= 0) 
			{
				m_AudioSource.Play ();
			}
		}
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log (dis);
		dis = Vector3.Distance (transform.position, Player.transform.position);

		if (dis < 45 && dis > 10&& health >0) {
			//Runs after the player.
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRunning", true);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isDead", false);
		} else if (dis <= 10 && health >0) {
			//Attacks the player
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", true);
			anim.SetBool ("isDead", false);


		} else if (health <= 0) {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isDead", true);

			Destroy (gameObject, 3f);

		}
		else if(health >0)
		{
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isDead", false);
		}
	
	}
}
