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

    void Start()
    {
        rRigidbody = GetComponent<Rigidbody>();
        position = transform.position;
    }

    void Update()
    {
        Movement();
        HUDCheck();
    }

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