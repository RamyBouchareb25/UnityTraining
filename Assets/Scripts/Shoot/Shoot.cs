using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] Transform SpownPoint;
    public float shootingForce;

    //Aiming

    [SerializeField] Camera Camera;
    Vector3 shootPos;
    
    // Update is called once per frame
    void Update()
    {
        //Aiming 

        Vector2 screenCenterPos = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.ScreenPointToRay(screenCenterPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f))
        {
            shootPos = hit.point;
        }

        Vector3 aimDir = (shootPos - SpownPoint.position).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bul = Instantiate(bullet, SpownPoint.position, Quaternion.identity);
            Rigidbody bul_rb = bul.AddComponent<Rigidbody>();
            bul_rb.useGravity = false;
            bul_rb.AddForce(aimDir * shootingForce, ForceMode.Impulse);
            Destroy(bul, 0.5f);

        }
   
    }
}
