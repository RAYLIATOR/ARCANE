using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	Animator animator;
	public static GameObject currentEnemy;
    public Image bloodOnScreenEffect;
    [SerializeField]
    GameObject head = null;
    
	[SerializeField]
	public static float playerHealth;
	public static float playerDamage;
    float movementSpeed = 0.0f;
    float walkSpeed = 10f;
    float runSpeed = 30f;

    [SerializeField]
    float maxMovementSpeed = 0.0f;

    [SerializeField]
    float mouseSensitivity = 0.0f;

    Rigidbody rRigidbody = null;

    Vector3 position = Vector3.zero;

    float xRotation = 0.0f;
    float yRotation = 0.0f;

    //Shooting
    float fireRate = 2f;
    float nextTimeToFire = 0f;
    public GameObject projectile;
    public Transform firePoint;

    public float maxForce;
    public float maxSpeed;

    void Start()
    {
		animator = GetComponentInChildren<Animator> ();
		playerDamage = 20f;
		playerHealth = 100f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rRigidbody = GetComponent<Rigidbody>();
        position = transform.position;
    }

    void Update()
    {
		Mathf.Clamp (playerHealth, 0, 100);
		bloodOnScreenEffect.color = new Color (1, 1, 1, (1-(playerHealth/100)));
        Movement();
        Shoot();
		Regen();
    }
    void Shoot()
    {
		if (Input.GetKeyDown (KeyCode.Mouse0) && Time.time >= nextTimeToFire) 
		{
			animator.SetTrigger ("Attack");
			nextTimeToFire = Time.time + 1f / fireRate;
			Invoke ("Fire", 1f);
		}
		else 
		{
			animator.SetTrigger ("Idle");
		}
    }
	void Fire()
	{		
		Instantiate (projectile, firePoint.position, transform.localRotation);
	}
	void Regen()
	{
		playerHealth += 0.01f;
	}
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rRigidbody.AddForce(transform.forward * maxForce);
        }

        if (Input.GetKey(KeyCode.S))
        {
			rRigidbody.AddForce(-transform.forward * maxForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
			rRigidbody.AddForce(transform.right * maxForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
			rRigidbody.AddForce(-transform.right * maxForce);
        }

		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			rRigidbody.velocity = new Vector3 (0.0f, rRigidbody.velocity.y, 0.0f);
		} else
		{
			animator.SetTrigger ("Walk");
		}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;
        }
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            movementSpeed = 0f;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        rRigidbody.velocity = Vector3.ClampMagnitude(rRigidbody.velocity, maxMovementSpeed);

        xRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (yRotation >= 50)
            yRotation = 50;
        if (yRotation <= -45)
            yRotation = -45;

        Camera.main.transform.localRotation = Quaternion.Euler(-yRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, xRotation, 0);
    }    
}
