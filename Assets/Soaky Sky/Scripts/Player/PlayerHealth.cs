using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int health;

    void Start()
    {

    }

    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            print("game over");
            Destroy(gameObject);
        }
    }

    public void TakeDamage ( int damage )
    {
        health -= damage;
    }
}
