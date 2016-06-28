using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour {

    public int bulletDamage;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
