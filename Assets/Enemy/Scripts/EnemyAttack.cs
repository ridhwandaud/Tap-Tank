using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int damage;
	void Start ()
    {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
