using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerMobile : MonoBehaviour
{
    //Components
    Animator rotateAnimator;

    //Handling
    public Transform rotateChild;
	public int bulletAmmo;
	public int totalBullet;
	public float time;
	public float attackTime;

    //GameObject
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float bulletSpeed;
	public bool isReadyToNextShoot = true;

	Vector2 direction,heading;

	float distance;

    void Start()
    {
        rotateAnimator = rotateChild.GetComponent<Animator>();
		totalBullet = bulletAmmo;
    }

    void Update()
    {
   
		if (GameObject.FindGameObjectWithTag ("Bullet") != null) {
			isReadyToNextShoot = true;
		}
		if (isReadyToNextShoot) {
			MousePosition ();
		}
    }

//    void Touch()
//    {
//        for (var i = 0; i < Input.touchCount; ++i)
//        {
//            Touch touch = Input.GetTouch(i);
//            int pointerID = touch.fingerId;
//
//            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) //Release
//            {
//                Shoot(1);
//            }
//
//        }
//    }

	void Reload()
	{
		bulletAmmo = totalBullet;
	}

	void MousePosition()
	{
		if (Input.GetMouseButton (0)) 
		{
			rotateChild.gameObject.SetActive(true);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rotateChild.rotation = Quaternion.LookRotation (Vector3.forward,transform.position - mousePos);

			heading = transform.position - mousePos;
			distance = heading.magnitude;
			direction = heading / distance;

		}
		else if (Input.GetMouseButtonUp (0))  // cooldown check
		{
			Shoot (direction);
			isReadyToNextShoot = false;
			time = 0;
		}
	}

	void Shoot(Vector2 direction)
    {
		bulletAmmo--;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
		bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed); //to add force according to rotation

		//Vector2 direction = bullet.transform.rotation*Vector2.up;

		//bullet.GetComponent<Ball>().setDirection(direction);
		rotateChild.gameObject.SetActive(false);
    }



}
