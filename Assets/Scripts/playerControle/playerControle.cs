using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControle : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    public float mouvementSpeed;

    Vector2 inputs;

    [SerializeField] Vector3 moveDirection;

    bool Isgrounded;

    public Transform GroundChecker;

    public Transform Camera;

    [SerializeField] AudioSource walkSound;
    [Header("Jump")]

    public float JumpForce;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // check the ground
     
        Isgrounded = Physics.CheckSphere(GroundChecker.position, 0.3f,LayerMask.GetMask("Ground"));
       
        // inputs
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Vertical");

        // mouvment Vector
        moveDirection = transform.forward * inputs.y  + transform.right * inputs.x ;

        if(moveDirection.magnitude > 0)
        {
            walkSound.Play();
        }
        else
        {
            walkSound.Stop();
        }
        //move only if grounded
        if (Isgrounded)
        {

            playerRigidbody.AddForce(moveDirection  * Time.deltaTime * mouvementSpeed * 10,ForceMode.Force);
        }
        else
        {
            playerRigidbody.AddForce(moveDirection * Time.deltaTime * mouvementSpeed * 3, ForceMode.Force);

        }

        //playerFollow Camera
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.localEulerAngles.y, transform.localEulerAngles.z);


        if (Input.GetKeyDown(KeyCode.Space) && Isgrounded)
        {
            Jump();
        }

        // Additionel Physic
        if(!Isgrounded)
         playerRigidbody.AddForce(-Vector3.up * 1000 * Time.deltaTime, ForceMode.Force);
    }

    void Jump()
    {
        playerRigidbody.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
}
