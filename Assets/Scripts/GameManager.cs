using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0,10)] [SerializeField] private float Timer = 5f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPlace;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        Timer -=  Time.deltaTime;
        if (Timer < 0)
        {
            Instantiate(enemy,new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)),Quaternion.identity);
            Timer = 5f;
        }
    }
}
