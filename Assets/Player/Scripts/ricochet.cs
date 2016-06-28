using UnityEngine;
using System.Collections;

public class ricochet : MonoBehaviour {

    // private static ricochet instance = null;
    // public static ricochet Instance { 
    //     get{
    //         return instance;
    //     }
    // }
	// public static ricochet instance = null;

	 public float speedforce;

   Vector2 direction;
   Rigidbody2D rigidBody2D;
   System.Random r;

//    void Awake(){

//        //Check if there is already an instance of SoundManager 
//  		if (instance == null) 
//  			//if not, set it to this. 
//  			instance = this; 
//  		//If instance already exists: 
//  		else if (instance != this) 
//  			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager. 
//  			Destroy (gameObject); 
 
 
//  		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene. 
//  		DontDestroyOnLoad (gameObject); 

//    }

    //-- error --> arrow position always at same place
    //--maybe kena dapatkan point arrow punya rotation then cari direction
    void Awake(){
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        Vector3 arrowPosition = GameObject.FindWithTag("Arrow").transform.rotation.eulerAngles;
        Debug.Log("arrowPosition "+arrowPosition);
        setDirection(arrowPosition);
    }

   void Start () 
   {
      //random object
    //   r = new System.Random();

    //   //random start direction
    //   direction = new Vector2((float)rnd(-1.0,1.0), (float)rnd(-1.0,1.0));
    
      //get rigidBody2D component
    //   rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    //   Vector2 arrowPosition = GameObject.FindWithTag("Arrow").transform.position;
    //   Debug.Log("arrowPosition "+arrowPosition);
    //   setDirection(Vector2.up);
      

      //set direction of ball adding force
    //   setDirection(direction);
   }

//    public void passDirection(Vector2 startDir){      
//        setDirection(startDir);
//    }

    //original -->private
   public void setDirection(Vector2 inDirection)  
   {
       Debug.Log("set direction run");
      if(!rigidBody2D)
         return;

      direction = inDirection;

      //Normalize directional vector
      direction.Normalize();

      if(speedforce>=0)
         speedforce = 600;

      //add force in the direction the ball bounces or starts
      rigidBody2D.AddForce(direction * speedforce);
   }
   
   double rnd( double a, double b )
   {
      return a + r.NextDouble()*(b-a);
   }

   void OnCollisionEnter2D(Collision2D collision)
   {
       Debug.Log("collide");
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
