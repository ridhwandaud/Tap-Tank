using UnityEngine;
using System.Collections;

public class Ball: MonoBehaviour 
{
	public float speedforce;

	Vector2 direction;
	Rigidbody2D rigidBody2D;
	System.Random r;

	void Start () 
	{
		//random object
		r = new System.Random();

		//random start direction
		direction = new Vector2((float)rnd(-1.0,1.0), (float)rnd(-1.0,1.0));

		//get rigidBody2D component
		rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

		//set direction of ball adding force
		setDirection(direction);
	}

	public void setDirection(Vector2 inDirection)
	{
		if(!rigidBody2D)
			return;

		direction = inDirection;

		//Normalize directional vector
		direction.Normalize();

		if(speedforce<=0)
			speedforce = 300;

		//add force in the direction the ball bounces or starts
		rigidBody2D.AddForce(direction * speedforce);
	}

	double rnd( double a, double b )
	{
		return a + r.NextDouble()*(b-a);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//reset force
		rigidBody2D.velocity = Vector2.zero;

		//obtain the surface normal for a point on a collider 
		Vector2 CollisionNormal = collision.contacts[0].normal;

		//Reflects a vector off the plane defined by a normal.
		direction = Vector3.Reflect(direction, CollisionNormal);

		//apply new direction adding force
		setDirection(direction);

	}
}