using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
			GameController.instance.NextLevel();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
