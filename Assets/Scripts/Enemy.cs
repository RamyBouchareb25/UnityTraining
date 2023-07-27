using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemy;
    private Transform player;

    [SerializeField] float health;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
         enemy.SetDestination(player.position);
    }

    public void TakeDmg(float dmg)
    {
        if(health - dmg > 0)
        {
            health = health - dmg;
        }
        else
        {
            // other
            Destroy(gameObject);
        }
    }
}
