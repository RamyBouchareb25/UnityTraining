using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [Range(0.1f, 20)]
    public float sensitivity;
    [SerializeField] Vector3 CameraPosition;
    float MouseX;
    float MouseY;

 
    void Start()
    {
     
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame

    void Update()
    {
        MouseX += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -10;
        MouseY += Input.GetAxis("Mouse X") * (sensitivity / (1.5f)) * Time.deltaTime * 10; 
     
        
        MouseX = Mathf.Clamp(MouseX, -10, 10);
        //MouseY = Mathf.Clamp(MouseY, -50, 50);
        transform.localEulerAngles = new Vector3(MouseX, MouseY, 0);

        transform.position = transform.rotation * CameraPosition + player.transform.position;

    }

   
}
