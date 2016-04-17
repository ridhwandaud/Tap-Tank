using UnityEngine;
using System.Collections;

public class HommingMissile : MonoBehaviour {

    public GameObject enemy; //your missile's target
    public float speed = 1;
    Rigidbody2D rb;

    private Vector2 dist = new Vector2();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        dist = enemy.transform.position - transform.position; //difference in space between target and player
        dist = dist.normalized; //makes sure it's based on direction. Without it, the missile slows down the closer the missile is to target.
        rb.AddForce(dist * speed *Time.deltaTime);
    }
}
