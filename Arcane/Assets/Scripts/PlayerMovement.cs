using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public Image HealthBarImage;
    public Image ManaBarImage;
    public Image HUDImage;
    [SerializeField]
    GameObject head = null;
    
    [SerializeField]
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
	//public GameObject IceBall;
	//public Transform firePosition;
	//public float timeShoot;
	//public float timeReset;
	//public int fireSpeed;


    void Start()
    {
        rRigidbody = GetComponent<Rigidbody>();
        position = transform.position;
		timeShoot = timeReset;
    }

    void Update()
    {
        Movement();
        HUDCheck();
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Instantiate()
        }
    }
	/*void FixedUpdate()
	{

		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			GameObject Temporary_Ball_Handler;
			Temporary_Ball_Handler = Instantiate (IceBall, firePosition.transform.position, firePosition.transform.rotation) as GameObject;

			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Ball_Handler.GetComponent<Rigidbody> ();


			Temporary_RigidBody.AddForce (transform.forward*fireSpeed);
	
			Destroy (Temporary_Ball_Handler, 10.0f);
		}

	}*/

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(head.transform.forward.x, 0.0f, head.transform.forward.z) * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(-head.transform.forward.x, 0.0f, -head.transform.forward.z) * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(head.transform.right.x, 0.0f, head.transform.right.z) * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-head.transform.right.x, 0.0f, -head.transform.right.z) * movementSpeed * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rRigidbody.velocity = new Vector3(0.0f, rRigidbody.velocity.y, 0.0f);
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

        transform.rotation = Quaternion.Euler(-yRotation, xRotation, 0);
    }    
    void HUDCheck()
    {
        if (movementSpeed == 0)
        {
            HealthBarImage.color -= new Color(0, 0, 0, 0.1f);
            ManaBarImage.color -= new Color(0, 0, 0, 0.1f);
            HUDImage.color -= new Color(0, 0, 0, 0.1f);
        }
        else
        {
            HUDImage.color += new Color(0, 0, 0, 0.1f);
            HealthBarImage.color += new Color(0, 0, 0, 0.1f);
            ManaBarImage.color += new Color(0, 0, 0, 0.1f);
        }
    }
}
