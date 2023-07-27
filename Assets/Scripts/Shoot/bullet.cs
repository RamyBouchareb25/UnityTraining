using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    [SerializeField] float dmg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Enemy en = other.GetComponent<Enemy>();
            en.TakeDmg(dmg);
        }
    }

 
}
