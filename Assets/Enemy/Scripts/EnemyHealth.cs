﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health;

	void Start()
    {

    }

    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
